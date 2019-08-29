using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_Persona.Models;

namespace CRUD_Persona
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
            
        {
            Actualizar();
       
        }

        #region HELPER
         
            

        private void Actualizar()
        {
            using (CRUDEntities db = new CRUDEntities())
            {
                var lst = from d in db.Persona
                          select d;
                dataGridView1.DataSource = lst.ToList();

            }
         }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());

            }
            catch
            {
                return null;
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            VIsta.FrmTabla oFrmTabla = new VIsta.FrmTabla();
            oFrmTabla.ShowDialog();

            Actualizar();

        }

      

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? id = GetId(); 
            if (id!= null)
            {
                VIsta.FrmTabla oFrmTabla = new VIsta.FrmTabla(id);
                oFrmTabla.ShowDialog();

                Actualizar();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                using (CRUDEntities db = new CRUDEntities())
                {
                    Persona oPersona = db.Persona.Find(id);
                    db.Persona.Remove(oPersona);

                    db.SaveChanges();
                }

                Actualizar();

               
            }
        }
    }
}
    