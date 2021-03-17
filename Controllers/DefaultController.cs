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
using Newtonsoft.Json;

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
        public ActionResult Mostrar(ListViewModel model)
        {
            return View();
        }


        [HttpGet]
        public ActionResult Mostrar(int Id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SeleccionarPersonal ";
       
            SqlDataAdapter adaptador = new SqlDataAdapter();
            List<ListViewModel> MostraDatos = new List<ListViewModel>();
            DataTable dtPersonal = new DataTable();    
            
            conexion.Open();
            comando.ExecuteNonQuery();
          
            MostraDatos = dtPersonal.AsEnumerable().Select(x => new ListViewModel
            {
                Id = (int)x["Id"],
                Nombre = (string)x["Nombre"],
                ApellidoPaterno = (string)x["ApellidoPaterno"],
                ApellidoMaterno = (string)x["ApellidoMaterno"],
                Edad = (int)x["Edad"],
                is_active = (bool)x["is_active"]
            }).ToList();
          

            adaptador.SelectCommand = comando;
            adaptador.Fill(dtPersonal);

            conexion.Close();

            return Json(MostraDatos, JsonRequestBehavior.AllowGet);


           

        }
        public ActionResult Nuevo(ListViewModel modelo)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(String Nombre, String ApellidoPaterno, String ApellidoMaterno, int Edad, bool Is_active)
        {

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "@Accion:Insert" ;


            comando.Parameters.AddWithValue("Nombre", Nombre);
            comando.Parameters.AddWithValue("ApellidoPaterno", ApellidoPaterno);
            comando.Parameters.AddWithValue("ApellidoMaterno", ApellidoMaterno);
            comando.Parameters.AddWithValue("Edad", Edad);
            comando.Parameters.AddWithValue("is_active", Is_active);

            conexion.Open();

            comando.ExecuteNonQuery();


            conexion.Close();
            return View(dtPersonal);
        }
        [HttpGet]
        public ActionResult Editar(String Nombre, String ApellidoPaterno, String ApellidoMaterno, int Edad, bool Is_active)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "MostrarEmpleado";

            comando.Parameters.AddWithValue("Nombre", Nombre);
            comando.Parameters.AddWithValue("ApellidoPaterno", ApellidoPaterno);
            comando.Parameters.AddWithValue("ApellidoMaterno", ApellidoMaterno);
            comando.Parameters.AddWithValue("Edad", Edad);
            comando.Parameters.AddWithValue("is_active", Is_active);




            SqlDataAdapter adaptador = new SqlDataAdapter();
            dtPersonal = new DataTable();

            conexion.Open();

            comando.ExecuteNonQuery();


            conexion.Close();

            return View(dtPersonal);

        }

        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "EliminarEstdiante";

            comando.Parameters.AddWithValue("pId", Id);

            conexion.Open();

            comando.ExecuteNonQuery();


            conexion.Close();
            return View(dtPersonal);
        }

        

    }
      
    }
