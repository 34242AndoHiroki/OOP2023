#define Mywork
#define Answer

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {

            // これは確認用
            Console.WriteLine(File.ReadAllText("employee.xml"));
            Console.WriteLine();

            Exercise1_2("employees.xml");
            Exercise1_3("employees.xml");
            Console.WriteLine();

            Exercise1_4("employees.json");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employees.json"));
        }

#if Mywork

        #region 自力


        private static void Exercise1_1(string v) {

            var employee = new Employee
            {
                Id = 1014,
                Name = "内山直人",
                HireDate = new DateTime(1999, 4, 1)
            };

            //シリアル化（XML方式）
            using (var writer = XmlWriter.Create(v)) {
                var serializer = new XmlSerializer(employee.GetType());
                serializer.Serialize(writer, employee);
            }

            //逆シリアル化(XML方式)
            using (var reader = XmlReader.Create(v)) {
                var serializer = new XmlSerializer(typeof(Employee));
                var serEmployee = serializer.Deserialize(reader) as Employee;
                Console.WriteLine(serEmployee);
            }

        }

        private static void Exercise1_2(string v) {

            var employees = new Employee[]
            {
                new Employee
                {
                    Id = 1007,
                    Name = "武藤正浩",
                    HireDate = new DateTime(1990, 4, 1)
                }
                ,
                new Employee
                {
                    Id = 1009,
                    Name = "福地和利",
                    HireDate = new DateTime(1993, 4, 1)
                }
                ,
                new Employee
                {
                    Id = 1013,
                    Name = "平の上政輝",
                    HireDate = new DateTime(1999, 4, 1)
                }
                ,
                new Employee
                {
                    Id = 1014,
                    Name = "内山直人",
                    HireDate = new DateTime(1999, 4, 1)
                }
                ,
                new Employee
                {
                    Id = 1015,
                    Name = "長谷川展弘",
                    HireDate = new DateTime(2002, 4, 1)
                }
                ,
                new Employee
                {
                    Id = 1025,
                    Name = "石橋祐典",
                    HireDate = new DateTime(2013, 8, 15)
                }
                    ,
                new Employee
                {
                    Id = 1058,
                    Name = "川邉昌一",
                    HireDate = new DateTime(2022, 10, 10)
                },

            };

            //シリアル化（XML方式）
            using (var writer = XmlWriter.Create(v)) {
                var serializer = new XmlSerializer(employees.GetType());
                serializer.Serialize(writer, employees);
            }

        }

        private static void Exercise1_3(string v) {
            Exercise1_2(v);

            //逆シリアル化(XML方式)
            using (var reader = XmlReader.Create(v)) {
                var serializer = new XmlSerializer(typeof(Employee[]));
                var serEmployees = serializer.Deserialize(reader) as Employee[];

                foreach (var employee in serEmployees) {
                    Console.WriteLine(employee);
                }
            }

        }

        private static void Exercise1_4(string v) {

            var employees = new Employee2[]
            {
                new Employee2
                {
                    Id = 1007,
                    Name = "武藤正浩",
                    HireDate = new DateTime(1990, 4, 1)
                }
                ,
                new Employee2
                {
                    Id = 1009,
                    Name = "福地和利",
                    HireDate = new DateTime(1993, 4, 1)
                }
                ,
                new Employee2
                {
                    Id = 1013,
                    Name = "平の上政輝",
                    HireDate = new DateTime(1999, 4, 1)
                }
                ,
                new Employee2
                {
                    Id = 1014,
                    Name = "内山直人",
                    HireDate = new DateTime(1999, 4, 1)
                }
                ,
                new Employee2
                {
                    Id = 1015,
                    Name = "長谷川展弘",
                    HireDate = new DateTime(2002, 4, 1)
                }
                ,
                new Employee2
                {
                    Id = 1025,
                    Name = "石橋祐典",
                    HireDate = new DateTime(2013, 8, 15)
                }
                    ,
                new Employee2
                {
                    Id = 1058,
                    Name = "川邉昌一",
                    HireDate = new DateTime(2022, 10, 10)
                },

            };

            using (var stream = new FileStream(v,FileMode.Create,FileAccess.Write)) {
                var serializer = new DataContractJsonSerializer(employees.GetType());
                serializer.WriteObject(stream, employees);
            }

        }
    }

    [DataContract(Name = "employee")]
    public class Employee2 {
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "hiredate")]
        public DateTime HireDate { get; set; }
    }

    #endregion

#elif Answer

    #region 模範解答

        private static void Exercise1_1(string v) {
            //Contentのほうを使ってやっても大丈夫です　でも、汎用性とかの観点からこっちのほうがよし

            var emp = new Employee
            {
                Id = 123,
                Name = "山田 博人",
                HireDate = new DateTime(2023, 9, 5)
            };

            using (var writer = XmlWriter.Create(v)) {
                var serializer = new XmlSerializer(emp.GetType());
                serializer.Serialize(writer, emp);
            }

            using (var reader = XmlReader.Create(v)) {
                var serializer = new XmlSerializer(typeof(Employee));
                var employee = serializer.Deserialize(reader) as Employee;
                Console.WriteLine(employee);
            }

        }

        private static void Exercise1_2(string v) {

            var emps = new Employee[]
            {
                new Employee
                {
                    Id = 123,
                    Name = "出井 秀行",
                    HireDate = new DateTime(2001, 5, 10)
                },
                new Employee
                {
                    Id = 139,
                    Name = "大橋 孝仁",
                    HireDate = new DateTime(2004, 12, 1)
                },
            };
            var settings = new XmlWriterSettings
            {
                Encoding = new System.Text.UTF8Encoding(false),
                //Encoding = new System.Text.ASCIIEncoding(),       //ASCII文字　変化なし
                Indent = true,
                IndentChars = "  ",     //インデントの表示方式
                //IndentChars = "*****"        //*の区切りができる

            };

            using (var writer = XmlWriter.Create(v,settings)) {
                var serializer = new DataContractSerializer(emps.GetType());
                serializer.WriteObject(writer, emps);
            }

            //settingsなしのやり方もいける　でもあった方が安全かも
            //using (var writer = XmlWriter.Create(v)) {
            //    var serializer = new DataContractSerializer(emps.GetType());
            //    serializer.WriteObject(writer, emps);
            //}
        }

        //逆シリアル化
        private static void Exercise1_3(string v) {
            using (var reader = XmlReader.Create(v)) {
                var serializer = new DataContractSerializer(typeof(Employee[]));
                var emps = serializer.ReadObject(reader) as Employee[];
                foreach (var emp in emps) {
                    Console.WriteLine("{0} {1} {2}",emp.Id,emp.Name,emp.HireDate);
                }
            }
        }

        private static void Exercise1_4(string v) {

            var emps = new Employee2[]
            {
                new Employee2
                {
                    Id = 123,
                    Name = "出井 秀行",
                    HireDate = new DateTime(2001, 5, 10)
                },
                new Employee2
                {
                    Id = 139,
                    Name = "大橋 孝仁",
                    HireDate = new DateTime(2004, 12, 1)
                },
            };

            using (var stream = new FileStream(v,FileMode.Create,FileAccess.Write)) {
                var serrializer = new DataContractJsonSerializer(emps.GetType());
                serrializer.WriteObject(stream, emps);
                //ここからはフォーマットとかのことだからいらない
                //stream.Close();
                //var jsonText = Encoding.UTF8.GetString(stream.ToArray());
                //Console.WriteLine(jsonText);
            }
        }

    }

    [DataContract]
    public class Employee2 {
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "hireDate")]
        public DateTime HireDate { get; set; }
    }
    #endregion
#endif

}
