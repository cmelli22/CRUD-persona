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

namespace CRUD_Persona.VIsta
{
    public partial class FrmTabla : Form
    {
        public int? id;
        Persona oPersona = null;
        public FrmTabla(int? id=null)
        
        {
            InitializeComponent();
            this.id = id;
            if (id != null)
            {
                CargarDatos();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CargarDatos()
        {
            using (CRUDEntities db = new CRUDEntities())
            {
                oPersona = db.Persona.Find(id);
                txtEmail.Text = oPersona.email;
                txtNombre.Text = oPersona.Nombre;
                dtpFechaNacimiento.Value = oPersona.Fecha_nacimiento;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (CRUDEntities db = new CRUDEntities())
            {
                if (id == null)
                    oPersona = new Persona();
               
               
                oPersona.Nombre = txtNombre.Text;
                oPersona.email = txtEmail.Text;
                oPersona.Fecha_nacimiento = dtpFechaNacimiento.Value;
               


                if (id == null)
                {
                    db.Persona.Add(oPersona);
                }
                else{
                    db.Entry(oPersona).State = System.Data.Entity.EntityState.Modified; 

                }

                db.SaveChanges();

                this.Close();
            }
        }

        private void FrmTabla_Load(object sender, EventArgs e)
        {
             
        }
    }
}
