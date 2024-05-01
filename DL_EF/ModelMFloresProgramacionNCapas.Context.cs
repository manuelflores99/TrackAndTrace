﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MFloresProgramacionNCapasEntities : DbContext
    {
        public MFloresProgramacionNCapasEntities()
            : base("name=MFloresProgramacionNCapasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Estado> Estadoes { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<Colonia> Colonias { get; set; }
        public virtual DbSet<EstatusTransporte> EstatusTransportes { get; set; }
        public virtual DbSet<Transporte> Transportes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Paquete> Paquetes { get; set; }
        public virtual DbSet<Repartidor> Repartidors { get; set; }
        public virtual DbSet<Asistencia> Asistencias { get; set; }
        public virtual DbSet<EstatusAsistencia> EstatusAsistencias { get; set; }
    
        public virtual ObjectResult<ColoniaGetById_Result> ColoniaGetById(Nullable<int> idColonia)
        {
            var idColoniaParameter = idColonia.HasValue ?
                new ObjectParameter("IdColonia", idColonia) :
                new ObjectParameter("IdColonia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ColoniaGetById_Result>("ColoniaGetById", idColoniaParameter);
        }
    
        public virtual ObjectResult<ColoniaGetByIdMunicipio_Result> ColoniaGetByIdMunicipio(Nullable<int> idMunicipio)
        {
            var idMunicipioParameter = idMunicipio.HasValue ?
                new ObjectParameter("IdMunicipio", idMunicipio) :
                new ObjectParameter("IdMunicipio", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ColoniaGetByIdMunicipio_Result>("ColoniaGetByIdMunicipio", idMunicipioParameter);
        }
    
        public virtual ObjectResult<EstadoGetByIdPais_Result> EstadoGetByIdPais(Nullable<int> idPais)
        {
            var idPaisParameter = idPais.HasValue ?
                new ObjectParameter("IdPais", idPais) :
                new ObjectParameter("IdPais", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EstadoGetByIdPais_Result>("EstadoGetByIdPais", idPaisParameter);
        }
    
        public virtual ObjectResult<MunicipioGetByIdEstado_Result> MunicipioGetByIdEstado(Nullable<int> idEstado)
        {
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("IdEstado", idEstado) :
                new ObjectParameter("IdEstado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MunicipioGetByIdEstado_Result>("MunicipioGetByIdEstado", idEstadoParameter);
        }
    
        public virtual ObjectResult<PaisGetAll_Result> PaisGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PaisGetAll_Result>("PaisGetAll");
        }
    
        public virtual ObjectResult<RolGetAll_Result> RolGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RolGetAll_Result>("RolGetAll");
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int TransporteAdd(string numeroPlaca, string modelo, string marca, Nullable<System.DateTime> anioFabricacion, Nullable<int> idEstatus)
        {
            var numeroPlacaParameter = numeroPlaca != null ?
                new ObjectParameter("NumeroPlaca", numeroPlaca) :
                new ObjectParameter("NumeroPlaca", typeof(string));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            var marcaParameter = marca != null ?
                new ObjectParameter("Marca", marca) :
                new ObjectParameter("Marca", typeof(string));
    
            var anioFabricacionParameter = anioFabricacion.HasValue ?
                new ObjectParameter("AnioFabricacion", anioFabricacion) :
                new ObjectParameter("AnioFabricacion", typeof(System.DateTime));
    
            var idEstatusParameter = idEstatus.HasValue ?
                new ObjectParameter("IdEstatus", idEstatus) :
                new ObjectParameter("IdEstatus", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("TransporteAdd", numeroPlacaParameter, modeloParameter, marcaParameter, anioFabricacionParameter, idEstatusParameter);
        }
    
        public virtual ObjectResult<TransporteGetById_Result> TransporteGetById(Nullable<int> idTransporte)
        {
            var idTransporteParameter = idTransporte.HasValue ?
                new ObjectParameter("IdTransporte", idTransporte) :
                new ObjectParameter("IdTransporte", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TransporteGetById_Result>("TransporteGetById", idTransporteParameter);
        }
    
        public virtual int TransporteUpdate(Nullable<int> idTransporte, string numeroPlaca, string modelo, string marca, Nullable<System.DateTime> anioFabricacion, Nullable<int> idEstatus)
        {
            var idTransporteParameter = idTransporte.HasValue ?
                new ObjectParameter("IdTransporte", idTransporte) :
                new ObjectParameter("IdTransporte", typeof(int));
    
            var numeroPlacaParameter = numeroPlaca != null ?
                new ObjectParameter("NumeroPlaca", numeroPlaca) :
                new ObjectParameter("NumeroPlaca", typeof(string));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            var marcaParameter = marca != null ?
                new ObjectParameter("Marca", marca) :
                new ObjectParameter("Marca", typeof(string));
    
            var anioFabricacionParameter = anioFabricacion.HasValue ?
                new ObjectParameter("AnioFabricacion", anioFabricacion) :
                new ObjectParameter("AnioFabricacion", typeof(System.DateTime));
    
            var idEstatusParameter = idEstatus.HasValue ?
                new ObjectParameter("IdEstatus", idEstatus) :
                new ObjectParameter("IdEstatus", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("TransporteUpdate", idTransporteParameter, numeroPlacaParameter, modeloParameter, marcaParameter, anioFabricacionParameter, idEstatusParameter);
        }
    
        public virtual int UsuarioAdd(string userName, string nombre, string apellidoPaterno, string apellidoMaterno, string email, string password, string sexo, string telefono, string celular, Nullable<System.DateTime> fechaNacimiento, string cURP, string imagen, Nullable<int> idRol, string calle, string numeroInterior, string numeroExterior, Nullable<int> idColonia)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var celularParameter = celular != null ?
                new ObjectParameter("Celular", celular) :
                new ObjectParameter("Celular", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var cURPParameter = cURP != null ?
                new ObjectParameter("CURP", cURP) :
                new ObjectParameter("CURP", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var numeroInteriorParameter = numeroInterior != null ?
                new ObjectParameter("NumeroInterior", numeroInterior) :
                new ObjectParameter("NumeroInterior", typeof(string));
    
            var numeroExteriorParameter = numeroExterior != null ?
                new ObjectParameter("NumeroExterior", numeroExterior) :
                new ObjectParameter("NumeroExterior", typeof(string));
    
            var idColoniaParameter = idColonia.HasValue ?
                new ObjectParameter("IdColonia", idColonia) :
                new ObjectParameter("IdColonia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioAdd", userNameParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, emailParameter, passwordParameter, sexoParameter, telefonoParameter, celularParameter, fechaNacimientoParameter, cURPParameter, imagenParameter, idRolParameter, calleParameter, numeroInteriorParameter, numeroExteriorParameter, idColoniaParameter);
        }
    
        public virtual int UsuarioDelete(Nullable<int> idUsuario, Nullable<int> idDireccion)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var idDireccionParameter = idDireccion.HasValue ?
                new ObjectParameter("IdDireccion", idDireccion) :
                new ObjectParameter("IdDireccion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioDelete", idUsuarioParameter, idDireccionParameter);
        }
    
        public virtual ObjectResult<UsuarioGetById_Result> UsuarioGetById(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetById_Result>("UsuarioGetById", idUsuarioParameter);
        }
    
        public virtual int UsuarioUpdate(Nullable<int> idUsuario, string userName, string nombre, string apellidoPaterno, string apellidoMaterno, string email, string password, string sexo, string telefono, string celular, Nullable<System.DateTime> fechaNacimiento, string cURP, string imagen, Nullable<int> idRol, Nullable<int> idDireccion, string calle, string numeroExterior, string numeroInterior, Nullable<int> idColonia)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var celularParameter = celular != null ?
                new ObjectParameter("Celular", celular) :
                new ObjectParameter("Celular", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var cURPParameter = cURP != null ?
                new ObjectParameter("CURP", cURP) :
                new ObjectParameter("CURP", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(string));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            var idDireccionParameter = idDireccion.HasValue ?
                new ObjectParameter("IdDireccion", idDireccion) :
                new ObjectParameter("IdDireccion", typeof(int));
    
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var numeroExteriorParameter = numeroExterior != null ?
                new ObjectParameter("NumeroExterior", numeroExterior) :
                new ObjectParameter("NumeroExterior", typeof(string));
    
            var numeroInteriorParameter = numeroInterior != null ?
                new ObjectParameter("NumeroInterior", numeroInterior) :
                new ObjectParameter("NumeroInterior", typeof(string));
    
            var idColoniaParameter = idColonia.HasValue ?
                new ObjectParameter("IdColonia", idColonia) :
                new ObjectParameter("IdColonia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioUpdate", idUsuarioParameter, userNameParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, emailParameter, passwordParameter, sexoParameter, telefonoParameter, celularParameter, fechaNacimientoParameter, cURPParameter, imagenParameter, idRolParameter, idDireccionParameter, calleParameter, numeroExteriorParameter, numeroInteriorParameter, idColoniaParameter);
        }
    
        public virtual int UsuarioUpdateEstatus(Nullable<int> idUsuario, Nullable<bool> estatus)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var estatusParameter = estatus.HasValue ?
                new ObjectParameter("Estatus", estatus) :
                new ObjectParameter("Estatus", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioUpdateEstatus", idUsuarioParameter, estatusParameter);
        }
    
        public virtual ObjectResult<UsuarioGetAll_Result> UsuarioGetAll(string nombre, string apellidoPaterno, string aPellidoMaterno)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var aPellidoMaternoParameter = aPellidoMaterno != null ?
                new ObjectParameter("APellidoMaterno", aPellidoMaterno) :
                new ObjectParameter("APellidoMaterno", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetAll_Result>("UsuarioGetAll", nombreParameter, apellidoPaternoParameter, aPellidoMaternoParameter);
        }
    
        public virtual int PaqueteAdd(string instruccionEntrega, Nullable<decimal> peso, string direccionOrigen, string direccionEntrega, Nullable<System.DateTime> fechaEstimadaEntrega, string numeroGuia, byte[] codigoQR)
        {
            var instruccionEntregaParameter = instruccionEntrega != null ?
                new ObjectParameter("InstruccionEntrega", instruccionEntrega) :
                new ObjectParameter("InstruccionEntrega", typeof(string));
    
            var pesoParameter = peso.HasValue ?
                new ObjectParameter("Peso", peso) :
                new ObjectParameter("Peso", typeof(decimal));
    
            var direccionOrigenParameter = direccionOrigen != null ?
                new ObjectParameter("DireccionOrigen", direccionOrigen) :
                new ObjectParameter("DireccionOrigen", typeof(string));
    
            var direccionEntregaParameter = direccionEntrega != null ?
                new ObjectParameter("DireccionEntrega", direccionEntrega) :
                new ObjectParameter("DireccionEntrega", typeof(string));
    
            var fechaEstimadaEntregaParameter = fechaEstimadaEntrega.HasValue ?
                new ObjectParameter("FechaEstimadaEntrega", fechaEstimadaEntrega) :
                new ObjectParameter("FechaEstimadaEntrega", typeof(System.DateTime));
    
            var numeroGuiaParameter = numeroGuia != null ?
                new ObjectParameter("NumeroGuia", numeroGuia) :
                new ObjectParameter("NumeroGuia", typeof(string));
    
            var codigoQRParameter = codigoQR != null ?
                new ObjectParameter("CodigoQR", codigoQR) :
                new ObjectParameter("CodigoQR", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PaqueteAdd", instruccionEntregaParameter, pesoParameter, direccionOrigenParameter, direccionEntregaParameter, fechaEstimadaEntregaParameter, numeroGuiaParameter, codigoQRParameter);
        }
    
        public virtual int PaqueteUpdate(Nullable<int> idPaquete, string instruccionEntrega, Nullable<decimal> peso, string direccionOrigen, string direccionEntrega, Nullable<System.DateTime> fechaEstimadaEntrega, string numeroGuia, byte[] codigoQR)
        {
            var idPaqueteParameter = idPaquete.HasValue ?
                new ObjectParameter("IdPaquete", idPaquete) :
                new ObjectParameter("IdPaquete", typeof(int));
    
            var instruccionEntregaParameter = instruccionEntrega != null ?
                new ObjectParameter("InstruccionEntrega", instruccionEntrega) :
                new ObjectParameter("InstruccionEntrega", typeof(string));
    
            var pesoParameter = peso.HasValue ?
                new ObjectParameter("Peso", peso) :
                new ObjectParameter("Peso", typeof(decimal));
    
            var direccionOrigenParameter = direccionOrigen != null ?
                new ObjectParameter("DireccionOrigen", direccionOrigen) :
                new ObjectParameter("DireccionOrigen", typeof(string));
    
            var direccionEntregaParameter = direccionEntrega != null ?
                new ObjectParameter("DireccionEntrega", direccionEntrega) :
                new ObjectParameter("DireccionEntrega", typeof(string));
    
            var fechaEstimadaEntregaParameter = fechaEstimadaEntrega.HasValue ?
                new ObjectParameter("FechaEstimadaEntrega", fechaEstimadaEntrega) :
                new ObjectParameter("FechaEstimadaEntrega", typeof(System.DateTime));
    
            var numeroGuiaParameter = numeroGuia != null ?
                new ObjectParameter("NumeroGuia", numeroGuia) :
                new ObjectParameter("NumeroGuia", typeof(string));
    
            var codigoQRParameter = codigoQR != null ?
                new ObjectParameter("CodigoQR", codigoQR) :
                new ObjectParameter("CodigoQR", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PaqueteUpdate", idPaqueteParameter, instruccionEntregaParameter, pesoParameter, direccionOrigenParameter, direccionEntregaParameter, fechaEstimadaEntregaParameter, numeroGuiaParameter, codigoQRParameter);
        }
    
        public virtual ObjectResult<RepartidorGetAll_Result> RepartidorGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RepartidorGetAll_Result>("RepartidorGetAll");
        }
    
        public virtual ObjectResult<RepartidorGetById_Result> RepartidorGetById(Nullable<int> idRepartidor)
        {
            var idRepartidorParameter = idRepartidor.HasValue ?
                new ObjectParameter("IdRepartidor", idRepartidor) :
                new ObjectParameter("IdRepartidor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RepartidorGetById_Result>("RepartidorGetById", idRepartidorParameter);
        }
    
        public virtual ObjectResult<UsuarioGetByEmail_Result> UsuarioGetByEmail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetByEmail_Result>("UsuarioGetByEmail", emailParameter);
        }
    }
}