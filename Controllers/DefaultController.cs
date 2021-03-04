using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Web.Controllers;
using System.Data.SqlClient;
using Web.Models.ViewModel;
//using System.Collections.Generic;

namespace Web.Controllers
{
    public class DefaultController : Controller
    {
        DataTable dtPersonal;
       SqlConnection conexion = new SqlConnection("Server =INT20005; Database=CrudMvc; Trusted_Connection=True;"); 
        [HttpGet]
        public ActionResult Index()

           
        {
            SqlCommand comando = new SqlCommand(); 
            comando.Connection = conexion; 
            comando.CommandType = CommandType.StoredProcedure; 
            comando.CommandText = "CargarPersonal"; 

            SqlDataAdapter adaptador = new SqlDataAdapter();
            dtPersonal = new DataTable(); 

            conexion.Open();

            adaptador.SelectCommand = comando;
            adaptador.Fill(dtPersonal);
            conexion.Close();

            return View(dtPersonal);

        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ListViewModel modelo)
        {

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "AgregarPersonal";

           

            conexion.Open();

            comando.ExecuteNonQuery();


            conexion.Close();
            return View(dtPersonal);
        }

        public ActionResult Editar(PersonalViewModel model)
        {
            return View();
        }

        public ActionResult Editar(int Id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "CargarEmpleado"; 

            comando.Parameters.AddWithValue("pId", Id);

            SqlDataAdapter adaptador = new SqlDataAdapter();
            dtPersonal = new DataTable();

            conexion.Open();

            adaptador.SelectCommand = comando;
            adaptador.Fill(dtPersonal);

            conexion.Close();

            return View(dtPersonal);

        }

            public ActionResult Eliminar()
        {
            return View();
        }

        public ActionResult Eliminar(String Nombre)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "EliminarEstdiante";


            comando.Parameters.AddWithValue("pNombre", Nombre);

            conexion.Open();

            comando.ExecuteNonQuery();


            conexion.Close();
            return View(dtPersonal);
        }

        

    }
      
    }
