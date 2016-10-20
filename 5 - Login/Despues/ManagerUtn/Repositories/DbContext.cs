using System.Collections.Generic;
using ManagerUtn.Entities;

namespace ManagerUtn.Repositories
{
    public static class DbContext
    {
        public static List<Book> Books { get; set; }


        static DbContext()
        {
            Books = new List<Book> {
                new Book{
                    Id = 1,
                    Titulo = "Estructuras de Datos y Algoritmos por Alfred V. Aho",
                    Descripcion = "DESCRIPCIÓN DEL TEXTO Esta obra ilustrada examina las estructuras de datos y los algoritmos que fundamentan gran parte de la programación actual de computadores. Se estudian las estructuras de datos y los algoritmos desde el amplio contexto de la solución de problemas con computador (escribiendo programas en Pascal)",
                    Image = "http://librosdeingenieriagratis.com/wp-content/uploads/2012/10/Estructura-de-Datos-y-Algoritmos-por-Alfred-V.jpg",
                    Comentarios = new List<Comment>
                    {
                        new Comment
                        {
                            Id = 1,
                            Comentario = "Primer comentario",
                            UserName = "Usuario1@test.com"
                        },
                           new Comment
                        {
                            Id = 2,
                            Comentario = "Segundo comentario",
                            UserName = "OtroUsuario@test.com"
                        }
                    }
                } ,new Book{
                    Id = 2,
                    Titulo = "Arquitectura del DBMS",
                    Descripcion = "Introducción a la arquitectura de Oracle. Paso previo para conocer de forma avanzada la administración de bases de datos Oracle. Manual realizado para el curso de programador de bases de datos relacionales.",
                    Image = "http://librosdeingenieriagratis.com/wp-content/uploads/2012/08/Box.Arquitectura.DBMS_.jpg",
                    Comentarios = new List<Comment>()
                }  ,new Book{
                    Id = 3,
                    Titulo = "Sistemas Operativos por Abraham Silberschatz y Peter Baer Galvin",
                    Descripcion = "Los Sistemas Operativos son una parte esencial de cualquier sistema de computador. Por lo mismo, un curso sobre sistemas operativos es una parte esencial de cualquier programa de educación en ciencias de la computación. Este libro está pensado como texto para un curso introductorio sobre sistemas operativos en el tercer o cuarto año de licenciatura o en el primer año de posgrado.",
                    Image = "http://librosysolucionarios.net/wp-content/uploads/2014/12/Sistemas-Operativos-5ta-Edici%C3%B3n-Abraham-Silberschatz-Peter-Baer-Galvin.jpg",
                    Comentarios = new List<Comment> {  new Comment
                        {
                            Id = 1,
                            Comentario = "Primer comentario",
                             UserName = "anonimo@test.com"
                        }
                    }
                }  ,new Book{
                    Id = 4,
                    Titulo = "Lógica Digital y Diseño de Computadores por Morris Mano",
                    Descripcion = "Este libro presenta los conceptos basicos usados en el diseño y analisis de los sistemas digitales e introduce los principios de la organizacion digital y su diseño. Presenta varios metodos y tecnicas adecuados para una gran variedad de aplicaciones de diseño del sistema digital. Cubre todos los aspectos del sistema digital, desde los circuitos de compuertas electronicas, hasta la estructura compleja de un sistema microcomputador.",
                    Image = "http://librosysolucionarios.net/wp-content/uploads/2014/10/L%C3%B3gica-Digital-y-Dise%C3%B1o-de-Computadores-1ra-Edicion-M.-Morris-Mano.jpg",
                    Comentarios = new List<Comment>()
                }  ,new Book{
                    Id = 5,
                    Titulo = "Patrones de diseño Tapa blanda",
                    Descripcion = "Uno de los mejores libros para introducirse en el mundo de los patrones de diseño de aplicaciones.Es una guía paso a paso, bastante completa. A pesar de ser del año 2002 no está excesivamente desactualizada",
                    Image = "http://image5.casadellibro.com/a/l/t0/55/9782746090255.jpg",
                    Comentarios = new List<Comment>()
                }  };
        }
    }
}