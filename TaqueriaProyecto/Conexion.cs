using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TaqueriaProyecto
{
    // Clase que maneja toda la conexion y las consultas a la base de datos
    internal class Conexion
    {
        // Datos de configuracion de la base de datos
        private string servidor = "localhost";
        private string puerto = "3308";
        private string baseDatos = "taqueria";
        private string usuario = "root";
        private string password = "";

        private MySqlConnection conexion;

        // Propiedades para leer y cambiar los datos de la conexion
        public string Servidor { get => servidor; set => servidor = value; }
        public string Puerto { get => puerto; set => puerto = value; }
        public string BaseDatos { get => baseDatos; set => baseDatos = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Password { get => password; set => password = value; }

        // Constructor que arma la cadena de conexion y crea el objeto de conexion
        public Conexion()
        {
            string cadenaConexion = $"Server={servidor};Port={puerto};Database={baseDatos};Uid={usuario};Pwd={password};";
            conexion = new MySqlConnection(cadenaConexion);
        }

        // Abre la conexion solo si esta cerrada
        public MySqlConnection AbrirConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir la conexión: " + ex.Message);
            }

            return conexion;
        }

        // Inserta un producto nuevo en la tabla productos
        public bool Insertar(string nombre, decimal precio, string tipo, bool disponible, string tortilla, string guiso, string tipoB, string tamanio)
        {
            // Consulta con parametros para evitar errores y datos invalidos
            string query = "INSERT INTO productos (nombre, precio, tipo, disponible) VALUES (@nombre, @precio, @tipo, @disponible)";



            try
            {
                MySqlConnection conn = AbrirConexion();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@disponible", disponible);


                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar producto: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        // Obtiene todos los productos con sus datos de taco o de bebida
        public DataTable Observar()
        {
            {
                // Se unen las tres tablas para traer toda la informacion del producto
                string query = @"SELECT productos.id_producto, productos.nombre, productos.precio, productos.tipo, productos.disponible,tacos.guiso,tacos.tortilla, bebidas.tipo AS tipo_bebida, bebidas.tamanio
                    FROM productos
                        LEFT JOIN tacos ON productos.id_producto = tacos.id_producto
                        LEFT JOIN bebidas ON productos.id_producto = bebidas.id_producto";

                DataTable dt = new DataTable();

                try
                {
                    MySqlConnection conn = AbrirConexion();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los productos: " + ex.Message);
                }
                finally
                {
                    CerrarConexion();
                }

                return dt;
            }


        }

        // Registra un cliente y devuelve el id que le asigno la base de datos
        public int RegistrarCliente(string nombre, string telefono)
        {
            // Consulta para guardar el cliente
            string query = "INSERT INTO clientes (nombre, telefono) VALUES (@nombre, @telefono)";

            try
            {
                MySqlConnection conn = AbrirConexion();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@telefono", telefono);

                    cmd.ExecuteNonQuery();
                }

                MySqlCommand comandoId = new MySqlCommand("SELECT LAST_INSERT_ID()", conn);

                return Convert.ToInt32(comandoId.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar cliente: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        // Obtiene la lista de clientes para llenar los combos
        public DataTable ObservarClientes()
        {
            string query = "SELECT id_cliente, nombre FROM clientes";
            DataTable dt = new DataTable();

            try
            {
                MySqlConnection conn = AbrirConexion();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar clientes: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return dt;
        }

        // Obtiene la lista de empleados
        public DataTable ObservarEmpleados()
        {
            string query = "SELECT id_empleado, nombre, puesto FROM empleados";

            try
            {
                MySqlConnection conn = AbrirConexion();

                DataTable tabla = new DataTable();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar empleados: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        // Elimina un empleado usando su id
        public void EliminarEmpleado(int id)
        {
            string query = "DELETE FROM empleados WHERE id_empleado = @id";

            try
            {
                MySqlConnection conn = AbrirConexion();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar empleado: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        // Registra un empleado nuevo
        public void RegistrarEmpleado(string nombre, string puesto)
        {
            string query = "INSERT INTO empleados (nombre, puesto) VALUES (@nombre, @puesto)";

            try
            {
                MySqlConnection conn = AbrirConexion();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@puesto", puesto);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar empleado: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        // Actualiza el nombre y el puesto de un empleado
        public void ActualizarEmpleado(int id, string nombre, string puesto)
        {
            string query = "UPDATE empleados SET nombre = @nombre, puesto = @puesto WHERE id_empleado = @id";

            try
            {
                MySqlConnection conn = AbrirConexion();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@puesto", puesto);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar empleado: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        // Obtiene solo los productos marcados como disponibles
        public DataTable ObservarProductos()
        {
            string query = "SELECT id_producto, nombre, precio FROM productos WHERE disponible = 1";
            DataTable dt = new DataTable();

            try
            {
                MySqlConnection conn = AbrirConexion();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar productos: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return dt;
        }

        // Registra una orden y devuelve el id generado
        public int RegistrarOrden(int idCliente, int idEmpleado, decimal total)
        {
            // Se guarda la fecha con NOW de MySQL
            string query = "INSERT INTO ordenes (id_cliente, id_empleado, fecha, total) VALUES (@cliente, @empleado, NOW(), @total)";

            try
            {
                MySqlConnection conn = AbrirConexion();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cliente", idCliente);
                    cmd.Parameters.AddWithValue("@empleado", idEmpleado);
                    cmd.Parameters.AddWithValue("@total", total);

                    cmd.ExecuteNonQuery();
                }

                MySqlCommand comandoId = new MySqlCommand("SELECT LAST_INSERT_ID()", conn);

                return Convert.ToInt32(comandoId.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la orden: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        // Registra una linea de detalle de la orden con cantidad precio y subtotal
        public void RegistrarDetalleOrden(int idOrden, int idProducto, int cantidad, decimal precio, decimal subtotal)
        {
            string query = "INSERT INTO detalle_orden (id_orden, id_producto, cantidad, precio_unitario, subtotal) VALUES (@orden, @producto, @cantidad, @precio, @subtotal)";

            try
            {
                MySqlConnection conn = AbrirConexion();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@orden", idOrden);
                    cmd.Parameters.AddWithValue("@producto", idProducto);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@subtotal", subtotal);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar detalle de orden: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        // Actualiza un producto y ademas sus datos de taco o de bebida segun el tipo
        public bool Actualizar(int id, string nombre, decimal precio, string tipo, bool disponible, string guiso, string tortilla, string tipoBebida, string tamanio)
        {
            // Primero se actualiza la tabla principal de productos
            string query = "UPDATE productos SET nombre = @nombre, precio = @precio, tipo = @tipo, disponible = @disponible WHERE id_producto = @id";

            try
            {
                MySqlConnection conn = AbrirConexion();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@disponible", disponible);

                    cmd.ExecuteNonQuery();
                }

                // Si es taco se actualiza la tabla tacos
                if (tipo == "Taco")
                {
                    string queryTaco = "UPDATE tacos SET guiso = @guiso, tortilla = @tortilla WHERE id_producto = @id";

                    using (MySqlCommand cmd = new MySqlCommand(queryTaco, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@guiso", guiso);
                        cmd.Parameters.AddWithValue("@tortilla", tortilla);

                        cmd.ExecuteNonQuery();
                    }
                }
                // Si es bebida se actualiza la tabla bebidas
                else if (tipo == "Bebida")
                {
                    string queryBebida = "UPDATE bebidas SET tipo = @tipo, tamanio = @tamanio WHERE id_producto = @id";

                    using (MySqlCommand cmd = new MySqlCommand(queryBebida, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@tipo", tipoBebida);
                        cmd.Parameters.AddWithValue("@tamanio", tamanio);

                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar producto: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        // Elimina un producto y sus datos relacionados en tacos y bebidas
        public bool Eliminar(int id)
        {
            // Se borran primero las tablas hijas para no dejar datos sueltos
            string queryTaco = "DELETE FROM tacos WHERE id_producto = @id";
            string queryBebida = "DELETE FROM bebidas WHERE id_producto = @id";
            string queryProducto = "DELETE FROM productos WHERE id_producto = @id";

            try
            {
                MySqlConnection conn = AbrirConexion();

                using (MySqlCommand cmd = new MySqlCommand(queryTaco, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                using (MySqlCommand cmd = new MySqlCommand(queryBebida, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                using (MySqlCommand cmd = new MySqlCommand(queryProducto, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar producto: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        // Obtiene las ordenes con el cliente el empleado el producto y los totales
        public DataTable ObservarOrdenes()
        {
            // Consulta con varias uniones para mostrar la orden completa
            string query = @"SELECT 
                    ordenes.id_orden,
                    clientes.nombre AS cliente,
                    empleados.nombre AS empleado,
                    ordenes.fecha,
                    productos.nombre AS producto,
                    detalle_orden.cantidad,
                    detalle_orden.precio_unitario,
                    detalle_orden.subtotal,
                    ordenes.total
                 FROM ordenes
                 INNER JOIN clientes
                 ON ordenes.id_cliente = clientes.id_cliente
                 INNER JOIN empleados
                 ON ordenes.id_empleado = empleados.id_empleado
                 INNER JOIN detalle_orden
                 ON ordenes.id_orden = detalle_orden.id_orden
                 INNER JOIN productos
                 ON detalle_orden.id_producto = productos.id_producto";

            try
            {
                MySqlConnection conn = AbrirConexion();

                DataTable tabla = new DataTable();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                    {
                        adaptador.Fill(tabla);
                    }
                }

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar órdenes: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }



        // Cierra la conexion si esta abierta
        public MySqlConnection CerrarConexion()
        {
            try
            {
                if (conexion != null &&
                    conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la conexión: " + ex.Message);
            }

            return conexion;
        }
    }
}
