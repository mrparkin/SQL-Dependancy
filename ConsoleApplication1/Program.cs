using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.EventArgs;

namespace SqlTableDependancy
{
    class Program
    {
        public static SqlCommand cmd;
        public static SqlConnection cs;
        public static SqlDataReader rdr;

        
        private static string con = @"Data Source=tcp:10.0.0.8\Repairs,1433;Initial Catalog=SAFETYNET_D; User Id=sa;Password=letmein;";
        

        

        static void Main(string[] args)
        {
            
            // The mapper object is used to map model properties that do not have a corresponding table column name.
            // In case all properties of your model have same name of table columns, you can avoid to use the mapper.
            var mapper = new ModelToTableMapper<location_name>();
            mapper.AddMapping(c => c.name, "status_number");

            // Here - as second parameter - we pass table name: this is necessary only if the model name is 
            // different from table name (in our case we have Customer vs Customers). 
            // If needed, you can also specifiy schema name.
            using (var dep = new SqlTableDependency<location_name>(con, tableName: "CALLS_V6", mapper: mapper))
            {
                dep.OnChanged += Changed;
                dep.Start();

                Console.WriteLine("Press a key to exit");
                Console.ReadKey();

                dep.Stop();
            }


        }// Main function to watch for mustad status in DB



        public static void Changed(object sender, RecordChangedEventArgs<location_name> e)
        {
            var changedEntity = e.Entity;
            Console.WriteLine("DML operation: " + e.ChangeType);


            List<active_RadioList> actRad = new List<active_RadioList>();
            if (changedEntity.name == "50")
            {
                Console.WriteLine("Mustard Alarm activated ->on status: " + changedEntity.name);

                Task.Delay(5000);
                cs = new SqlConnection(con);
                cs.Open();
                cmd = new SqlCommand("SELECT * FROM RADIOS_V13 WHERE location!='Muster Point' ", cs);


                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine(rdr["call_sign"].ToString());
                    actRad.Add(new active_RadioList (rdr["call_sign"].ToString(), rdr["call_sign"].ToString(), rdr["call_sign"].ToString()));
                }
                    cs.Close();

            }
        }


    }
}
