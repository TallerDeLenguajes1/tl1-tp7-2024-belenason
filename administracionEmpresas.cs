namespace admin
{
    enum Cargos
    {
        Auxiliar,
        Administrativo,
        Ingeniero,
        Especialista,
        Investigador
    }
    class Empleado
    {
        private string nombre;
        private string apellido;
        private DateTime fechaNac;
        private char estadoCivil;
        private DateTime fechaIngreso;
        private double sueldoBasico;
        private Cargos cargo;

        public string Nombre { get => nombre; set => nombre = value; }

        public string Apellido { get => apellido; set => apellido = value; }

        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }

        public char EstadoCivil { get => estadoCivil; set => estadoCivil = value; }

        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }

        public double SueldoBasico { get => sueldoBasico; set => sueldoBasico = value; }

        public Cargos Cargo { get => cargo; set => cargo = value; }

        public int antiguedad()
        {
            DateTime actual = DateTime.Now;
            int antig = actual.Year - fechaIngreso.Year;
            if (actual.Month < fechaIngreso.Month || (actual.Month == fechaIngreso.Month && actual.Day<fechaIngreso.Day)) antig--;
            return antig;
        }
        public int edad()
        {
            DateTime actual = DateTime.Now;
            int edad = actual.Year - fechaNac.Year;
            if (actual.Month < fechaNac.Month || (actual.Month == fechaNac.Month && actual.Day<fechaNac.Day)) edad--;
            return edad;
        }

        public int aniosFaltantesJubilarse()
        {
            int edade = edad();
            int falta = 65 - edade;
            return falta;
        }

        public double salario()
        {
            int antig = antiguedad();
            double adicional;
            if (antig < 20)
            {
               adicional = sueldoBasico*(antig/100); 
            } else
            {
                adicional = sueldoBasico*0.25; 
            }
            if (cargo == Cargos.Ingeniero || cargo == Cargos.Especialista)
            {
                adicional = adicional * 1.5;
            }
            if (estadoCivil == 'c' || estadoCivil == 'C')
            {
                adicional = adicional + 150000;
            }
            double Salario = sueldoBasico + adicional;
            return Salario;
        }
    }
}