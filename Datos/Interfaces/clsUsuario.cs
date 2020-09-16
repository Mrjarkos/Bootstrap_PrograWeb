using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public class clsUsuario
    {
        public string Insertar(Datos.USUARIO usuario) {
            try
            {
                using (DatabaseEntitiesDataModel obCnx = new DatabaseEntitiesDataModel())
                {
                    obCnx.USUARIO.Add(usuario);
                    obCnx.SaveChanges();
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            return "Operación exitosa: Insertar";
        }

        public string Modificar(Datos.USUARIO usuario)
        {
            try
            {
                using (DatabaseEntitiesDataModel obCnx = new DatabaseEntitiesDataModel())
                {
                    USUARIO user_ant= (from q in obCnx.USUARIO
                                         where q.ID == usuario.ID
                                         select q).First();
                    user_ant = usuario;
                    obCnx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Operación exitosa: Modificar";
        }

        public string Eliminar(long Id)
        {
            try
            {
                using (DatabaseEntitiesDataModel obCnx = new DatabaseEntitiesDataModel())
                {
                    USUARIO user_ant = (from q in obCnx.USUARIO
                                                  where q.ID == Id
                                                  select q).First();
                    obCnx.USUARIO.Remove(user_ant);
                    obCnx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "Operación exitosa: Eliminar";
        }

        public List<USUARIO> Consultar() {
            try
            {
                using (DatabaseEntitiesDataModel obCnx = new DatabaseEntitiesDataModel())
                {
                    List<USUARIO> usuarios = (from q in obCnx.USUARIO
                                                        select new USUARIO { 
                                                        DOCUMENTO = q.DOCUMENTO,
                                                        PASSWORD = q.PASSWORD,
                                                        NOMBRE= q.NOMBRE,
                                                        ID = q.ID,
                                                        CORREO =q.CORREO,
                                                        DOC_TYPE = q.DOC_TYPE,
                                                        ROL = q.ROL
                                                        }).ToList();
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<USUARIO> Consultar(long id)
        {
            try
            {
                using (DatabaseEntitiesDataModel obCnx = new DatabaseEntitiesDataModel())
                {
                    List<USUARIO> usuarios = (from q in obCnx.USUARIO
                                                        where q.ID == id
                                                        select new USUARIO
                                                        {
                                                            DOCUMENTO = q.DOCUMENTO,
                                                            PASSWORD = q.PASSWORD,
                                                            NOMBRE = q.NOMBRE,
                                                            ID = q.ID,
                                                            CORREO = q.CORREO,
                                                            DOC_TYPE = q.DOC_TYPE,
                                                            ROL = q.ROL
                                                        }).ToList();
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
