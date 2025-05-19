namespace GymFlash.Model
{
    public class UserModel
    {
        public UserModel()
        {
            // Inicializar todos los campos numéricos con "0"
            Edad = "0";
            Peso = "0";
            Altura = "0";
            IMC = "0";

            // Campos de texto como empty string
            Username = "";
            Password = "";
            Name = "";
            Lastname = "";
            Email = "";
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Edad { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }
        public string IMC { get; set; }
        public int ID_TipoMembresia { get; set; }
        public int ID_TipoUsuario { get; set; }


    }
}
