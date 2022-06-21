
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario_Rol
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_rol { get; set; }
    
        public virtual Usuario_Rol Rol { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
