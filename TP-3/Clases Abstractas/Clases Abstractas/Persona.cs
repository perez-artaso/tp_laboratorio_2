using System;
using System.Text;
using Excepciones;

namespace EntidadesAbstractas
{
    public class Persona
    {
        #region Atributos

        string _apellido;
        string _nombre;
        int _dni;
        ENacionalidad _nacionalidad;

        #endregion

        #region Propiedades
        public string Apellido
        {
            get => _apellido;

            set
            {
                //Utilizo una variable auxiliar para no llamar más de una vez al método
                //de validación y además para poder informar al usuario qué caracter ingresado
                //es el que no se acepta. 

                string auxStr = ValidarNombreApellido(value);

                try
                {
                    if (auxStr == "OK")
                    {
                        this._apellido = value;
                    }
                    else if (auxStr == null)
                    {
                        throw new ArgumentNullException("La Cadena Que Se Intentó Asignar" +
                            "Al Atributo 'Apellido' Tiene Como Valor NULL");

                    }
                    else
                        throw new NombreApellidoNoValidoException(String.Format("El Caracter {0} No Es Valido", auxStr));

                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (NombreApellidoNoValidoException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public string Nombre
        {
            get => _nombre;
            set
            {
                //Utilizo una variable auxiliar para no llamar más de una vez al método
                //de validación y además para poder informar al usuario qué caracter ingresado
                //es el que no se acepta. 

                string auxStr = ValidarNombreApellido(value);

                try
                {
                    if (auxStr == "OK")
                    {
                        this._nombre = value;
                    }
                    else if (auxStr == null)
                    {
                        throw new ArgumentNullException("La Cadena Que Se Intentó Asignar" +
                            "Al Atributo 'Nombre' Tiene Como Valor NULL");

                    }
                    else
                        throw new NombreApellidoNoValidoException(String.Format("El Caracter {0} No Es Valido", auxStr));

                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (NombreApellidoNoValidoException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public int DNI
        {
            get => _dni;
            set
            {
                try
                {
                    //Utilizo una variable auxiliar para no tener que llamar más de una vez al método de validación.
                    int auxRetornoMetodo = ValidarDni(this.Nacionalidad, value);

                    //En base a lo devuelto por la función, manejo los cuatro posibles resultados:
                    //Si el valor retornado es -1 (el valor recibido por la propiedad de asignación está
                    //por fuera del rango permitido), lanzo la excepción pertinente.
                    //Si el valor devuelto es 1 (el valor recibido por la propiedad de asignación está
                    //por dentro del rango permitido), se asigna el valor al atributo _dni.
                    //Si el valor retornado es -7 (el DNI no se corresponde -está por fuera del rango-
                    //con la nacionalidad), lanzo la excepción pertinente.
                    //Si el valor devuelto es 0 (la nacionalidad no ha sido asignada aún), lanzo la excepción
                    //pertinente.
                    if (auxRetornoMetodo == -1)
                    {
                        throw new DniInvalidoException("El DNI ingresado no es válido");
                    }
                    else if (auxRetornoMetodo == 1)
                    {
                        this._dni = value;
                    }
                    else if(auxRetornoMetodo == -7)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    else
                    {
                        throw new NacionalidadNoAsignadaException("La nacionalidad de la persona no " +
                            "ha sido establecida aun. \nEs necesario especificarla para poder asignar un DNI.");
                    }
                }

                //Atrapo las posibles excepciones.
                catch (DniInvalidoException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (NacionalidadNoAsignadaException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public string StringToDni
        {
            set
            {
                //El código es prácticamente el mismo que el del setter de la propiedad DNI.
                //Si no fuera porque en las consignas se especifica que hay que desarrollar 
                //un método que reciba el string que ingresa como valor a la presente propiedad
                //(ValidarDni(ENacionalidad nacionalidad, string dato) : int)), yo optaría
                //por realizar un int.TryParse(value, out unaVariableAuxiliar) en el setter
                //de esta propiedad y luego this.DNI = unaVariableAuxiliar haría el resto del trabajo. 

                try
                {
                    //Utilizo una variable auxiliar para no tener que llamar más de una vez al método de validación.
                    int auxRetornoMetodo = ValidarDni(this.Nacionalidad, value);


                    //En base a lo devuelto por la función, manejo los cuatro posibles resultados:
                    //Si el valor retornado es -1 (el valor recibido por la propiedad de asignación está
                    //por fuera del rango permitido), lanzo la excepción pertinente.
                    //Si el valor devuelto es 1 (el valor recibido por la propiedad de asignación está
                    //por dentro del rango permitido), se asigna el valor al atributo _dni.
                    //Si el valor devuelto es 0 (la nacionalidad no ha sido asignada aún), lanzo la excepción
                    //pertinente.
                    //Si el valor devuelto es -7 (el valor que recibe para evaluar es NULL) se lanza
                    //la excepción pertinente.
                    if (auxRetornoMetodo == -1)
                    {
                        throw new DniInvalidoException("El DNI ingresado no es válido");
                    }
                    else if (auxRetornoMetodo == 1)
                    {
                        int.TryParse(value, out _dni);
                    }
                    else if (auxRetornoMetodo == -7)
                    {
                        throw new NacionalidadInvalidaException();

                    }
                    else
                    {
                        throw new NacionalidadNoAsignadaException("La nacionalidad de la persona no " +
                            "ha sido establecida aun. \nEs necesario especificarla para poder asignar un DNI.");
                    }
                }

                //Atrapo las posibles excepciones.
                catch (DniInvalidoException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (NacionalidadNoAsignadaException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public ENacionalidad Nacionalidad { get => _nacionalidad; set => _nacionalidad = value; }
        #endregion

        #region Constructores
        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)

        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        #endregion

        #region Métodos

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retValue = 0;

            //Si nacionalidad es 0, significa que ésta aún no ha sido asignada.
            //Siendo que la nacionalidad es el parámetro fundamental sobre el que
            //evaluaremos si el DNI es válido o no, este método avisa que dicho 
            //atributo no ha sido asignado mediante el retorno del valor numerico '0'.
            //El valor de retorno '1' indica que el dato ingresado es válido y '-1'
            //indica lo contrario. 

            if (nacionalidad != 0)
            {
                if (nacionalidad == ENacionalidad.Argentino)
                {
                    //Verifico si el dato está dentro del rango permitido.

                    if (dato > 89999999 || dato < 1)
                    {
                        retValue = -1;
                    }
                    else
                    {
                        retValue = 1;
                    }
                }
                //Si no es Argentino y tiene número de DNI de un Argentino, indico que debe lanzar una excepción.
                else
                {
                    if (dato <= 89999999)
                    {
                        retValue = -7;
                    }
                    else
                    {
                        retValue = 1;
                    }
                }
            }
            else
            {
                retValue = 0;
            }
            return retValue;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retValue = 0;

            //Este método reutiliza casi íntegramente el código de su homónimo. 
            //Antes bien se asegura de que la cadena ingresada no valga null. 
            //En realidad, al utilizar el método estático TryParse para intentar
            //pasar la cadena a un valor numérico, de valer esta cadena null, 
            //el valor cargado en 'auxDato' sería 0, lo que finalmente llevaría
            //al código a indicarle al usuario que el valor ingresado no es válido. 
            //Sin embargo, puede ser importante que el usuario sepa que el valor 
            //no es válido por nulo y no por estar fuera de rango. 

            if (dato != null)
            {
                int auxDato;
                int.TryParse(dato, out auxDato);
                retValue = ValidarDni(nacionalidad, auxDato);
            }
            else
                retValue = -7;

            return retValue;

        }

        private string ValidarNombreApellido(string dato)
        {
            //Si la cadena que entra es null, el valor de retorno es null.
            //Si la cadena que entra contiene algún caracter no válido, 
            //lo retorna (de tener más de uno, devuelve el primero que se encuentre).
            //Si la cadena contiene únicamente letras, se devuelve "OK", indicando que la cadena es válida. 

            int longitud = dato.Length;
            string retStr = "OK";
            if (dato != null)
            {
                for (int i = 0; i < longitud; i++)
                {
                    //En base a la tabla ASCII puede realizarse la siguiente verificación:
                    //Si está por debajo de la 'A', entre la 'Z' y la 'a' o por encima de la 'z',
                    //el caracter no es una letra del alfabeto latino.

                    //Lo más práctico es usar expresiones regulares, pero a fin de cuentas, 
                    //ésta mecánica es sencilla exhaustiva.

                    if ((dato[i] < 'A') || (dato[i] > 'Z' && dato[i] < 'a') || (dato[i] > 'z'))
                    {
                        //Considero las vocales con acento.
                        if (!(dato[i] > 'á' && dato[i] < 'ú') && dato[i] != 'é')
                        {
                            //Por último, las vocales mayúsculas. (Supongo que alguien podría llamarse Áaron).
                            if (dato[i] != 'Á' && dato[i] != 'É' && dato[i] != 'Í' && dato[i] != 'Ó' && dato[i] != 'Ú')
                            {
                                retStr = dato[i].ToString();
                                break;
                            }
                        }
                    }
                }
            }
            else
                retStr = null;

            return retStr;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("Nombre: {0}", this.Nombre));
            sb.AppendLine(String.Format("Apellido: {0}", this.Apellido));
            sb.AppendLine(String.Format("Nacionalidad: {0}", this.Nacionalidad));
            sb.AppendLine(String.Format("DNI: {0}", this.DNI));

            return sb.ToString();

        }
        #endregion 

        #region Enumerado
        public enum ENacionalidad
        {
            //Asigno '1' como valor para "Argentino" a modo de poder chequear 
            //si un atributo de tipo ENacionalidad ha sido definido o no (caso
            //en el que contendrá el valor por default: 0).
            Argentino = 1,
            Extranjero
        };
        #endregion
    }
}