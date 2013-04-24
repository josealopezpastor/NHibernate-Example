using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                var hibernateConfiguration = new Configuration().Configure();
                var sessionFactory = hibernateConfiguration.BuildSessionFactory();

                var schemaExport = new SchemaExport(hibernateConfiguration);
                schemaExport.Create(false, true);
            }
            catch (Exception err)
            {

            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
