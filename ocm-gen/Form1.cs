using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ocm_gen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XDocument doc;

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            doc = XDocument.Load(@"emu_ocm1_gen.L5X");
            Display();
            buttonSave.Enabled = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            doc.Save(@"emu_ocm1_gen+.L5X");
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            buttonCloneAIn.Enabled = (treeViewRoutines.SelectedNode != null);
            buttonCloneDIn.Enabled = (treeViewRoutines.SelectedNode != null);
            buttonCloneValveMO.Enabled = (treeViewRoutines.SelectedNode != null);
            buttonCloneMotor.Enabled = (treeViewRoutines.SelectedNode != null);
            buttonCloneValveSO.Enabled = (treeViewRoutines.SelectedNode != null);
            buttonCloneRoutine.Enabled = (treeViewRoutines.SelectedNode != null);
            textBoxSource.Text = treeViewRoutines.SelectedNode.Text;
        }

        private void Display()
        {
            treeViewRoutines.Nodes.Clear();
            var routines = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Programs")
                .Elements("Program")
                .First(x => x.Attribute("Name").Value == "AIn")
                .Elements("Routines")
                .Elements("Routine")
                .ToList();

            foreach (var routine in routines)
                treeViewRoutines.Nodes.Add(routine.Attribute("Name").Value);

            textBoxJSR.Clear();
            foreach (var routine in routines)
                textBoxJSR.AppendText(routine.Attribute("Name").Value + "\r\n");

            treeViewGlobalTags.Nodes.Clear();
            var tags = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Tags")
                .Elements("Tag")
                .ToList();
            foreach (var tag in tags)
                treeViewGlobalTags.Nodes.Add(tag.Attribute("Name").Value);

            treeView3.Nodes.Clear();
            tags = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Programs")
                .Elements("Program")
                .First(x => x.Attribute("Name").Value == "AIn")
                .Elements("Tags")
                .Elements("Tag")
                .ToList();
            foreach (var tag in tags)
                treeView3.Nodes.Add(tag.Attribute("Name").Value);
        }

        private bool NotFound(string name)
        {
            var routines = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Programs")
                .Elements("Program")
                .First(x => x.Attribute("Name").Value == "AIn")
                .Elements("Routines")
                .Elements("Routine")
                .ToList();
            var found = routines.Find(x => x.Attribute("Name").Value == name);
            return (found == null);
        }

        private void buttonCloneAIn_Click(object sender, EventArgs e)
        {
            var oldName = textBoxSource.Text;

            foreach (string newName in textBoxNew.Lines)
            {
                if (newName.Length > 0)
                {
                    if (NotFound(newName))
                        CloneAIn(oldName, newName);
                    else
                        textBoxLog.AppendText(newName + " already exists\r\n");
                }    
            }
            Display();
        }

        private void CloneAIn(string oldName, string newName)
        {
            //////// CLONE ROUTINE

            var aiRoutines = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Programs")
                .Elements("Program")
                .First(x => x.Attribute("Name").Value == "AIn")
                .Elements("Routines")
                .Elements("Routine");
            var srcRoutine = aiRoutines.First(x => x.Attribute("Name").Value == oldName);

            XElement newRoutine = new XElement(srcRoutine);
            newRoutine.SetAttributeValue("Name", newName);

            List<XElement> nodes = (from n in newRoutine.Descendants()
                                    where n.Attributes("Operand").Any() && n.Attribute("Operand").Value.Contains(oldName)
                                    select n).ToList();
            nodes.ForEach(n => n.Attribute("Operand").Value = n.Attribute("Operand").Value.Replace(oldName, newName));

            srcRoutine.Parent.Add(newRoutine);

            ///////// CLONE GLOBAL TAGS

            var gtags = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Tags")
                .Elements("Tag");


            var srcTag = gtags.First(x => x.Attribute("Name").Value == oldName);
            XElement newTag = new XElement(srcTag);
            newTag.SetAttributeValue("Name", newName);
            srcTag.Parent.Add(newTag);

            srcTag = gtags.First(x => x.Attribute("Name").Value == oldName + "_Chan");
            newTag = new XElement(srcTag);
            newTag.SetAttributeValue("Name", newName + "_Chan");
            srcTag.Parent.Add(newTag);

            ///////// CLONE PROGRAM TAGS

            var ptags = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Programs")
                .Elements("Program")
                .First(x => x.Attribute("Name").Value == "AIn")
                .Elements("Tags")
                .Elements("Tag");

            var members = new List<string> {
                "_Inp_Raw",
                "_Inp_Raw_ChanFault",
                "_Inp_Raw_ModFault"
            };

            foreach (string suffix in members)
            {
                srcTag = ptags.First(x => x.Attribute("Name").Value == oldName + suffix);
                newTag = new XElement(srcTag);
                newTag.SetAttributeValue("Name", newName + suffix);
                srcTag.Parent.Add(newTag);
            };
        }

        private void buttonCloneDIn_Click(object sender, EventArgs e)
        {
            var oldName = textBoxSource.Text;

            foreach (string newName in textBoxNew.Lines)
            {
                if (newName.Length > 0)
                {
                    if (NotFound(newName))
                        CloneDIn(oldName, newName);
                    else
                        textBoxLog.AppendText(newName + " already exists\r\n");
                }
            }

            Display();
        }

        private void CloneDIn(string oldName, string newName)
        {
            //////// CLONE ROUTINE

            var diRoutines = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Programs")
                .Elements("Program")
                .First(x => x.Attribute("Name").Value == "DIn")
                .Elements("Routines")
                .Elements("Routine");
            var srcRoutine = diRoutines.First(x => x.Attribute("Name").Value == oldName);

            XElement newRoutine = new XElement(srcRoutine);
            newRoutine.SetAttributeValue("Name", newName);

            List<XElement> nodes = (from n in newRoutine.Descendants()
                                    where n.Attributes("Operand").Any() && n.Attribute("Operand").Value.Contains(oldName)
                                    select n).ToList();
            nodes.ForEach(n => n.Attribute("Operand").Value = n.Attribute("Operand").Value.Replace(oldName, newName));

            srcRoutine.Parent.Add(newRoutine);

            ///////// CLONE GLOBAL TAGS

            var gtags = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Tags")
                .Elements("Tag");


            var srcTag = gtags.First(x => x.Attribute("Name").Value == oldName);
            XElement newTag = new XElement(srcTag);
            newTag.SetAttributeValue("Name", newName);
            srcTag.Parent.Add(newTag);

            ///////// CLONE PROGRAM TAGS

            var ptags = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Programs")
                .Elements("Program")
                .First(x => x.Attribute("Name").Value == "DIn")
                .Elements("Tags")
                .Elements("Tag");

            var members = new List<string> {
                "_PVBad_Bor",
                "_Inp_PV",
                "_Inp_PV_ChanFault",
                "_Inp_PV_ModFault"
            };

            foreach (string suffix in members)
            {
                srcTag = ptags.First(x => x.Attribute("Name").Value == oldName + suffix);
                newTag = new XElement(srcTag);
                newTag.SetAttributeValue("Name", newName + suffix);
                srcTag.Parent.Add(newTag);
            };
        }

        private void buttonCloneValveMO_Click(object sender, EventArgs e)
        {
            var oldName = textBoxSource.Text;

            foreach (string newName in textBoxNew.Lines)
            {
                if (newName.Length > 0)
                {
                    if (NotFound(newName))
                        CloneValveMO(oldName, newName);
                    else
                        textBoxLog.AppendText(newName + " already exists\r\n");
                }
            }

            Display();
        }

        private void CloneValveMO(string oldName, string newName)
        {
            //////// CLONE ROUTINE

            var ValveMORoutines = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Programs")
                .Elements("Program")
                .First(x => x.Attribute("Name").Value == "ValveMO")
                .Elements("Routines")
                .Elements("Routine");
            var srcRoutine = ValveMORoutines.First(x => x.Attribute("Name").Value == oldName);

            XElement newRoutine = new XElement(srcRoutine);
            newRoutine.SetAttributeValue("Name", newName);

            List<XElement> nodes = (from n in newRoutine.Descendants()
                                    where n.Attributes("Operand").Any() && n.Attribute("Operand").Value.Contains(oldName)
                                    select n).ToList();
            nodes.ForEach(n => n.Attribute("Operand").Value = n.Attribute("Operand").Value.Replace(oldName, newName));

            srcRoutine.Parent.Add(newRoutine);

            ///////// CLONE GLOBAL TAGS

            var gtags = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Tags")
                .Elements("Tag");

            var srcTag = gtags.First(x => x.Attribute("Name").Value == oldName);
            XElement newTag = new XElement(srcTag);
            newTag.SetAttributeValue("Name", newName);
            srcTag.Parent.Add(newTag);

            ///////// CLONE PROGRAM TAGS

            var ptags = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Programs")
                .Elements("Program")
                .First(x => x.Attribute("Name").Value == "ValveMO")
                .Elements("Tags")
                .Elements("Tag");

            var members = new List<string> { 
                "_Out_Open",
                "_Out_Close",
                "_Out_Stop",
                "_Inp_OpenLS",
                "_Inp_ClosedLS",
                "_Inp_ActuatorFault",
                "_Inp_Ready",
                "_Inp_IOFault",
                "_Inp_Hand"
            };

            foreach (string suffix in members)
            {
                srcTag = ptags.First(x => x.Attribute("Name").Value == oldName + suffix);
                newTag = new XElement(srcTag);
                newTag.SetAttributeValue("Name", newName + suffix);
                srcTag.Parent.Add(newTag);
            };
        }

        private void buttonCloneMotor_Click(object sender, EventArgs e)
        {
            var oldName = textBoxSource.Text;

            foreach (string newName in textBoxNew.Lines)
            {
                if (newName.Length > 0)
                {
                    if (NotFound(newName))
                        CloneMotor(oldName, newName);
                    else
                        textBoxLog.AppendText(newName + " already exists\r\n");
                }
            }

            Display();
        }

        private void CloneMotor(string oldName, string newName)
        {
            //////// CLONE ROUTINE

            var MotorRoutines = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Programs")
                .Elements("Program")
                .First(x => x.Attribute("Name").Value == "Motor")
                .Elements("Routines")
                .Elements("Routine");
            var srcRoutine = MotorRoutines.First(x => x.Attribute("Name").Value == oldName);

            XElement newRoutine = new XElement(srcRoutine);
            newRoutine.SetAttributeValue("Name", newName);

            List<XElement> nodes = (from n in newRoutine.Descendants()
                                    where n.Attributes("Operand").Any() && n.Attribute("Operand").Value.Contains(oldName)
                                    select n).ToList();
            nodes.ForEach(n => n.Attribute("Operand").Value = n.Attribute("Operand").Value.Replace(oldName, newName));

            srcRoutine.Parent.Add(newRoutine);

            ///////// CLONE GLOBAL TAGS

            var gtags = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Tags")
                .Elements("Tag");

            var srcTag = gtags.First(x => x.Attribute("Name").Value == oldName);
            XElement newTag = new XElement(srcTag);
            newTag.SetAttributeValue("Name", newName);
            srcTag.Parent.Add(newTag);

            ///////// CLONE PROGRAM TAGS

            var ptags = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Programs")
                .Elements("Program")
                .First(x => x.Attribute("Name").Value == "Motor")
                .Elements("Tags")
                .Elements("Tag");

            var members = new List<string> {
                "_Out_Run",
                "_Out_Stop",
                "_Inp_RunFdbk",
                "_Inp_Ready",
                "_Inp_IOFault",
                "_Inp_Hand"
            };

            foreach (string suffix in members)
            {
                srcTag = ptags.First(x => x.Attribute("Name").Value == oldName + suffix);
                newTag = new XElement(srcTag);
                newTag.SetAttributeValue("Name", newName + suffix);
                srcTag.Parent.Add(newTag);
            };
        }

        private void buttonCloneValveSO_Click(object sender, EventArgs e)
        {
            var oldName = textBoxSource.Text;

            foreach (string newName in textBoxNew.Lines)
            {
                if (newName.Length > 0)
                {
                    if (NotFound(newName))
                        CloneValveSO(oldName, newName);
                    else
                        textBoxLog.AppendText(newName + " already exists\r\n");
                }
            }

            Display();
        }

        private void CloneValveSO(string oldName, string newName)
        {
            //////// CLONE ROUTINE

            var ValveSORoutines = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Programs")
                .Elements("Program")
                .First(x => x.Attribute("Name").Value == "ValveSO")
                .Elements("Routines")
                .Elements("Routine");
            var srcRoutine = ValveSORoutines.First(x => x.Attribute("Name").Value == oldName);

            XElement newRoutine = new XElement(srcRoutine);
            newRoutine.SetAttributeValue("Name", newName);

            List<XElement> nodes = (from n in newRoutine.Descendants()
                                    where n.Attributes("Operand").Any() && n.Attribute("Operand").Value.Contains(oldName)
                                    select n).ToList();
            nodes.ForEach(n => n.Attribute("Operand").Value = n.Attribute("Operand").Value.Replace(oldName, newName));

            srcRoutine.Parent.Add(newRoutine);

            ///////// CLONE GLOBAL TAGS

            var gtags = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Tags")
                .Elements("Tag");

            var srcTag = gtags.First(x => x.Attribute("Name").Value == oldName);
            XElement newTag = new XElement(srcTag);
            newTag.SetAttributeValue("Name", newName);
            srcTag.Parent.Add(newTag);

            ///////// CLONE PROGRAM TAGS

            var ptags = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Programs")
                .Elements("Program")
                .First(x => x.Attribute("Name").Value == "ValveSO")
                .Elements("Tags")
                .Elements("Tag");

            var members = new List<string> {
                "_Out",
                "_Inp_OpenLS",
                "_Inp_ClosedLS",
                "_Inp_IOFault"
            };

            foreach (string suffix in members)
            {
                srcTag = ptags.First(x => x.Attribute("Name").Value == oldName + suffix);
                newTag = new XElement(srcTag);
                newTag.SetAttributeValue("Name", newName + suffix);
                srcTag.Parent.Add(newTag);
            };
        }

        private void buttonCloneRoutine_Click(object sender, EventArgs e)
        {
            var oldName = textBoxSource.Text;

            foreach (string newName in textBoxNew.Lines)
            {
                if (newName.Length > 0)
                {
                    CloneRoutine(oldName, newName);
                }
            }

            Display();
        }

        private void CloneRoutine(string oldName, string newName)
        {
            //////// CLONE ROUTINE

            var routines = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Programs")
                .Elements("Program")
                .First(x => x.Attribute("Name").Value == "ValveMO")
                .Elements("Routines")
                .Elements("Routine");

            var existingRoutine = routines.First(x => x.Attribute("Name").Value == newName);
            existingRoutine.Remove();

            var srcRoutine = routines.First(x => x.Attribute("Name").Value == oldName);

            XElement newRoutine = new XElement(srcRoutine);
            newRoutine.SetAttributeValue("Name", newName);

            List<XElement> nodes = (from n in newRoutine.Descendants()
                                    where n.Attributes("Operand").Any() && n.Attribute("Operand").Value.Contains(oldName)
                                    select n).ToList();
            nodes.ForEach(n => n.Attribute("Operand").Value = n.Attribute("Operand").Value.Replace(oldName, newName));

            srcRoutine.Parent.Add(newRoutine);

            ///////// CLONE PROGRAM TAGS

            var ptags = doc.Elements("RSLogix5000Content")
                .Elements("Controller")
                .Elements("Programs")
                .Elements("Program")
                .First(x => x.Attribute("Name").Value == "ValveMO")
                .Elements("Tags")
                .Elements("Tag");

            string suffix = "_BNOT_Hand";
            var srcTag = ptags.First(x => x.Attribute("Name").Value == oldName + suffix);
            var newTag = new XElement(srcTag);
            newTag.SetAttributeValue("Name", newName + suffix);
            srcTag.Parent.Add(newTag);
        }
    }
}
