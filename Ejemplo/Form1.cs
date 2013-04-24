using Ejemplo.Entities;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



        }

        private void buttonCrearEmpleado_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado()
            {
                Nombre = textBoxNombre.Text.ToString(),
                Direccion = textBoxDireccion.Text.ToString(),
                Telefono = textBoxTelefono.Text.ToString(),
                Fax = textBoxFax.Text.ToString()
            };

            try
            {
                var hibernateConfiguration = new Configuration().Configure();
                var sessionFactory = hibernateConfiguration.BuildSessionFactory();

                var session = sessionFactory.OpenSession();
                var tx = session.BeginTransaction();

                session.Save(empleado);

                tx.Commit();
            }
            catch (Exception err) { }
        }

        private void buttonLeerEmpleados_Click(object sender, EventArgs e)
        { 
            var nhConfig = new Configuration().Configure();
            var sessionFactory = nhConfig.BuildSessionFactory();

            var session = sessionFactory.OpenSession();
            var tx = session.BeginTransaction();

            var empleados = GetEmpleados(session);

            foreach (Empleado empleado in empleados)
            {
                Console.WriteLine(empleado.Nombre + " " + empleado.Direccion
                    + " " + empleado.Telefono + " " + empleado.Fax + "\n");
            }
        }

        static IList<Empleado> GetEmpleados(ISession session)
        {
            var query = session.CreateCriteria<Empleado>()
                .AddOrder(Order.Asc("Nombre"));
            return query.List<Empleado>();
        }

    }
}
