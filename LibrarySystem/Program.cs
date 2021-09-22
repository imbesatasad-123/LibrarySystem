using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace LibrarySystem
{ 
    class libDAL
    {
        public SqlDataReader getlibtable()
        {    
            SqlDataReader reader = null;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "server=LAB_1_CO_2\\SQLEXPRESS;database=project;trusted_connection=true";
                con.Open();
                SqlCommand cmd = new SqlCommand("getlibtable", con);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Execution" + ex.Message);

            }
            return reader;
      }
        public SqlDataReader search(string bookname)
        {
            SqlDataReader reader = null;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "server=LAB_1_CO_2\\SQLEXPRESS;database=project;trusted_connection=true";
                con.Open();
                SqlCommand cmd = new SqlCommand("search", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("bookid", bookname);
                cmd.Parameters.Add(param);
                reader = cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Execution" + ex.Message);

            }
            return reader;
        }
        public int insertdatlib(int bookid, string bookname, string author,string category, int price)
        {
            int no = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "server=LAB_1_CO_2\\SQLEXPRESS;database=project;trusted_connection=true";
                con.Open();
                SqlCommand cmd = new SqlCommand("insertdatalib", con);
                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.AddWithValue("bk",bookid);
                cmd.Parameters.AddWithValue("bn",bookname);
                cmd.Parameters.AddWithValue("author",author);
                cmd.Parameters.AddWithValue("cat",category);
                cmd.Parameters.AddWithValue("price",price);
                no = cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Execution" + ex.Message);

            }
            return no;
           
        }
        public int updatedatlib(int bookid, string bookname,  string author,string category, int price)
        {

            int no = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "server=LAB_1_CO_2\\SQLEXPRESS;database=project;trusted_connection=true";
                con.Open();
                SqlCommand cmd = new SqlCommand("updatedatalib", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("bk", bookid);
                cmd.Parameters.AddWithValue("bn", bookname);
                cmd.Parameters.AddWithValue("author", author);
                cmd.Parameters.AddWithValue("cat", category);
                cmd.Parameters.AddWithValue("price", price);
                no = cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Execution" + ex.Message);

            }
            return no;
        }
        public int deletelib(int bookid)
        {

            int no = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "server=LAB_1_CO_2\\SQLEXPRESS;database=project;trusted_connection=true";
                con.Open();
                SqlCommand cmd = new SqlCommand("deletelib", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("bk", bookid);
                
                no = cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Execution" + ex.Message);

            }
            return no;
        }

    }

    class library
    {
        libDAL dal = new libDAL();
       public int bookid
        { 
          get;
          set;
        }
        public string bookname
        {
            get;
            set;
        }
        public string author
        {
            get;
            set;
        }
        public string category
        {
            get;
            set;
        }
        public int price
        {
            get;
            set;
        }

        public void printlibdata()
        {
            SqlDataReader reader = dal.getlibtable();
            Console.WriteLine("bookid\tbookname\tauthor\tcategory\tprice");
            while (reader.Read())
            {
                Console.WriteLine(reader[0] + "\t" + reader[1] + "\t" + reader[2] + "\t" + reader[3] + "\t" + reader[4]);
            }
        }
        public void printlib()
        {
            SqlDataReader reader = dal.search(bookname);
            Console.WriteLine("bookid\tbookname\tauthor\tcategory\tprice");
            while (reader.Read())
            {
                Console.WriteLine(reader[0] + "\t" + reader[1] + "\t" + reader[2] + "\t" + reader[3] + "\t" + reader[4]);
            }
        }
        public void insert()
        {
            int no = dal.insertdatlib(bookid, bookname, author, category, price);
            if (no > 0)
            {
                Console.WriteLine("dataninserted");
            }
        }
        public void update()
        {
            int no = dal.insertdatlib(bookid, bookname, author, category, price);
            if (no > 0)
            {
                Console.WriteLine("update ");
            }
        }
        public void delete()
        {
            int no = dal.deletelib(bookid);
            if (no > 0)
            {
                Console.WriteLine("deleted");
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            char ch;
            do
            {
                Console.WriteLine("menu");
                Console.WriteLine("1. Print Library Table");
                Console.WriteLine("2. Print Library Table based Book id");
                Console.WriteLine("3. insert");
                Console.WriteLine("4. upadte");
                Console.WriteLine("5. delete");
                Console.WriteLine("enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        library l = new library();
                        l.printlibdata();
                        break;
                    case 2:
                        library lib = new library();
                        Console.WriteLine("Enter book id to view book");
                        lib.bookid = Convert.ToInt32(Console.ReadLine());
                        lib.printlib();
                        break;
                    case 3:
                        library li = new library();
                        Console.WriteLine("Enter deatils in the following form bookid ,name,author,category,price");
                        li.bookid = Convert.ToInt32(Console.ReadLine());
                        li.bookname = Console.ReadLine();
                        li.author = Console.ReadLine();
                        li.category = Console.ReadLine();
                        li.price = Convert.ToInt32(Console.ReadLine());
                        li.insert();
                        break;
                    case 4:
                        library li1 = new library();
                        Console.WriteLine("Enter deatils to update in the following form bookid ,name,author,category,price");
                        li1.bookid = Convert.ToInt32(Console.ReadLine());
                        li1.bookname = Console.ReadLine();
                        li1.author = Console.ReadLine();
                        li1.category = Console.ReadLine();
                        li1.price = Convert.ToInt32(Console.ReadLine());
                        li1.update();
                        break;

                    case 5:
                        library li2 = new library();
                        Console.WriteLine("Enter bookid to be deleted");
                        li2.bookid = Convert.ToInt32(Console.ReadLine());

                        li2.delete();
                        break;
                    default:
                        Console.WriteLine("invalid");
                        break;
                }
                Console.WriteLine("do you what to continue  press y");
                ch = Convert.ToChar(Console.ReadLine());
            }
            while (ch == 'Y' || ch =='y');
            Console.ReadLine();
        }
    }
}
