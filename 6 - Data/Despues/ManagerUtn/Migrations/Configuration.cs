using System.Collections.Generic;
using ManagerUtn.Entities;
using ManagerUtn.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ManagerUtn.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ManagerUtn.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ManagerUtn.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com" };

                manager.Create(user, "password");

                roleManager.Create(new IdentityRole { Name = "Admin" });
                manager.AddToRole(user.Id, "Admin");
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            context.Books.AddOrUpdate(x => x.Titulo,
                new Book
                {
                    Id = 1,
                    Titulo = "Estructuras de Datos y Algoritmos por Alfred V. Aho",
                    Descripcion = "DESCRIPCIÓN DEL TEXTO Esta obra ilustrada examina las estructuras de datos y los algoritmos que fundamentan gran parte de la programación actual de computadores. Se estudian las estructuras de datos y los algoritmos desde el amplio contexto de la solución de problemas con computador (escribiendo programas en Pascal)",
                    Image = "http://librosdeingenieriagratis.com/wp-content/uploads/2012/10/Estructura-de-Datos-y-Algoritmos-por-Alfred-V.jpg"
                }, new Book
                {
                    Id = 2,
                    Titulo = "Arquitectura del DBMS",
                    Descripcion = "Introducción a la arquitectura de Oracle. Paso previo para conocer de forma avanzada la administración de bases de datos Oracle. Manual realizado para el curso de programador de bases de datos relacionales.",
                    Image = "http://librosdeingenieriagratis.com/wp-content/uploads/2012/08/Box.Arquitectura.DBMS_.jpg"
                }, new Book
                {
                    Id = 3,
                    Titulo = "Sistemas Operativos por Abraham Silberschatz y Peter Baer Galvin",
                    Descripcion = "Los Sistemas Operativos son una parte esencial de cualquier sistema de computador. Por lo mismo, un curso sobre sistemas operativos es una parte esencial de cualquier programa de educación en ciencias de la computación. Este libro está pensado como texto para un curso introductorio sobre sistemas operativos en el tercer o cuarto año de licenciatura o en el primer año de posgrado.",
                    Image = "http://librosysolucionarios.net/wp-content/uploads/2014/12/Sistemas-Operativos-5ta-Edici%C3%B3n-Abraham-Silberschatz-Peter-Baer-Galvin.jpg"
                    
                }, new Book
                {
                    Id = 4,
                    Titulo = "Lógica Digital y Diseño de Computadores por Morris Mano",
                    Descripcion = "Este libro presenta los conceptos basicos usados en el diseño y analisis de los sistemas digitales e introduce los principios de la organizacion digital y su diseño. Presenta varios metodos y tecnicas adecuados para una gran variedad de aplicaciones de diseño del sistema digital. Cubre todos los aspectos del sistema digital, desde los circuitos de compuertas electronicas, hasta la estructura compleja de un sistema microcomputador.",
                    Image = "http://librosysolucionarios.net/wp-content/uploads/2014/10/L%C3%B3gica-Digital-y-Dise%C3%B1o-de-Computadores-1ra-Edicion-M.-Morris-Mano.jpg"
                }, new Book
                {
                    Id = 5,
                    Titulo = "Patrones de diseño Tapa blanda",
                    Descripcion = "Uno de los mejores libros para introducirse en el mundo de los patrones de diseño de aplicaciones.Es una guía paso a paso, bastante completa. A pesar de ser del año 2002 no está excesivamente desactualizada",
                    Image = "http://image5.casadellibro.com/a/l/t0/55/9782746090255.jpg"
                }, new Book
                {
                    Id = 5,
                    Titulo = "Patterns of Enterpise Application Architecture",
                    Descripcion = "Seguramente ya conozcas los patrones de diseño o te hayas pegado con alguno. El concepto es muy sencillo: soluciones probadas aplicadas a problemas recurrentes. Pero por lo general son soluciones locales que ni implican más allá de 2 o 3 clases que resuelven problemas concretos en el desarrollo (vale, hay algunos patrones que condicionan toda la arquitectura). Pero cuando se trata de aplicaciones “grandes”",
                    Image = "https://www.adictosaltrabajo.com/wp-content/uploads/2016/05/patterns-1.png"
                });    

            //
        }
    }
}
