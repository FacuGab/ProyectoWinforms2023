﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace AccesoDatos
{
    public class Database
    {
        //TODO: VARIABLES DATABASE
        public SqlDataReader reader { get; set; }
        private SqlConnection connection;
        private SqlCommand command;

        //METODOS:
        // TODO: ABRIR CONEXION (cadena de conexion aca)
            //cadena manu = "server=Manulo-PC\\SQLLABO; database = CATALOGO_P3_DB; integrated security = true"
            //cadena facu = "server=.; database = CATALOGO_P3_DB; integrated security = true"
        public bool AbrirConexion(string path = "server=.; database = CATALOGO_P3_DB; integrated security = true")
        {
            try
            {
                connection = new SqlConnection(path);
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }  
        //TODO: CERRAR CONEXION
        public void CerrarConexion()
        {
            try
            {
                reader?.Close();
                reader?.Dispose();
                command?.Dispose();
                connection.Close();
                connection.Dispose();
                // ¿ que hace realmente el Dispose, elimina todos los recursos asociados al obj instaciado ?
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //TODO: SETEAR DATOS
        public void setQuery(string query) 
        {
            try
            {
                command = new SqlCommand(query, connection);
            }
            catch (Exception ex)
            {
                command.Dispose();
                throw ex;
            }
        }
        //TODO: LEER DATOS 
        public void readData()
        {
            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                command.Dispose();
                throw ex;
            }
        }
        //TODO: EJECUTAR
        public int executeQuery()
        {// podria retornar un int para obtener info de los datos afectados ¿?
            try
            {
               return command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //TODO: SETEAR PARAMETROS
        public void setearParamento(string nombre, object valor)
        {
            command.Parameters.AddWithValue(nombre, valor);
        }
    }//fin
}
