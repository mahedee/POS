using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        private int childFormNumber = 0;

        private Form frmObj;
       

        public MainForm()
        {
            InitializeComponent();
            frmObj = new login();
            frmObj.ShowDialog();
            LoadMenu();
        }



        private void LoadMenu()
        {
            string selectmenu = "SELECT [menu_id] ,[parent_menu_id],[menu_name],[form_name],[menu_level] FROM [IMS].[dbo].[menu] where [menu_level]='1' and [Menu_Id]=1";//(select Menu_Id from User_Permission where User_Id='" + DBConnection.userID + "' and User_Permission.View_Permission='1'  and Menu_Table.Menu_Id=User_Permission.Menu_Id)";
            DataSet ds = dbadmin.ReturnDataSet(selectmenu);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Name = dr[0].ToString();
                    item.Text = dr[2].ToString();
                    menuStrip.Items.Add(item);


                    string selectSubMenu = string.Format("SELECT [menu_id] ,[parent_menu_id],[menu_name],[form_name],[menu_level] FROM [IMS].[dbo].[menu] where [menu_level]='2' and parent_menu_id='{0}'", dr[0]);// and [Menu_Id]=(select Menu_Id from User_Permission where Menu_Table.Menu_Id=1)";// where User_Id='" + DBConnection.userID + "' and User_Permission.View_Permission='1' and Menu_Table.Menu_Id=User_Permission.Menu_Id)";

                    DataSet dsSubMenu = dbadmin.ReturnDataSet(selectSubMenu);
                    if (dsSubMenu.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow drSubMenu in dsSubMenu.Tables[0].Rows)
                        {
                            ToolStripMenuItem subItem = new ToolStripMenuItem();
                            subItem.Name = drSubMenu[0].ToString();
                            //subItem.ShortcutKeys = Keys.Alt|Keys.A;
                            subItem.Text = drSubMenu[2].ToString();
                            item.DropDownItems.Add(subItem);
                            subItem.Click += new EventHandler(MenuItemClickHandler);
                        }
                    }

                }
            }
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

                string selectClickedForm = string.Format("SELECT [menu_id] ,[parent_menu_id],[menu_name],[form_name],[menu_level] FROM [IMS].[dbo].[menu] where menu_id='{0}'", clickedItem.Name);
                DataSet ds = dbadmin.ReturnDataSet(selectClickedForm);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CloseAllRunForm();
                    Type type = Type.GetType("WindowsFormsApplication1." + ds.Tables[0].Rows[0][3].ToString());
                    frmObj = Activator.CreateInstance(type) as Form;
                    frmObj.MdiParent = this;

                    //frmObj1 = Activator.CreateInstance(type) as object;
                    //InsertComand = type.GetMethod("InsertComand");
                    //EditComand = type.GetMethod("EditComand");
                    //DeleteComand = type.GetMethod("DeleteComand");
                    //resize = type.GetMethod("resizeGroupBox");

                    frmObj.Show();

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Form not found. ");
            }
        }


        private void CloseAllRunForm()
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }

        }


        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
