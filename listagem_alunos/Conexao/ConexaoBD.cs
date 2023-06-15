using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace listagem_alunos
{
    public class ConexaoBD
    {
        
        
        private NpgsqlConnection conn   ;
        private NpgsqlCommand    command;

        private string user     = "postgres" ;
        private string password = "postgres" ;
        private string host     = "localhost";
        private string port     = "5432"     ;
        private string database = "postgres" ;



        public ConexaoBD()       
        {
            conn = new NpgsqlConnection($"User ID={user};Password={password};Host={host};Port={port};Database={database};");
        }



        private NpgsqlCommand CriaComandoSQL(string commandstring) 
        {
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = conn;
            command.CommandText = commandstring;

            return command;
        }



        // CRUD ESCOLA
        public void AddEscolaDB(Escola escolacadastro)
        {
            try
            {
                string commandstring =
                    "INSERT INTO escolas (nome)" +
                    $"VALUES ('{escolacadastro.Nome}');";
                
                command = CriaComandoSQL(commandstring);
                command.ExecuteNonQuery();
            }


            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }


            finally { conn.Close(); }
        }



        public List<Escola> ReadEscola() 
        {
            List<Escola> listreturn = new List<Escola>();
            try
            {
                string commandstring = "select * from escolas";

                command = CriaComandoSQL(commandstring);
                NpgsqlDataReader dr = command.ExecuteReader(); 


                if (dr.HasRows) //Preenche o listreturn com a lista das escolas
                {
                    while (dr.Read())
                    {
                        listreturn.Add(new Escola(
                            dr.GetInt32(0),
                            dr.GetString(1))

                            );
                    }
                }
            }


            catch (Exception) 
            {
                throw; 
            }


            finally { conn.Close(); }
            return listreturn;
        }



        public void AtualizaEscolaDB(Escola Escolaselecionada) 
        {
            try
            {
                string commandstring =
                    $"UPDATE escolas SET nome = '{Escolaselecionada.Nome}' WHERE id = {Escolaselecionada.Id};" +
                    $"UPDATE alunos SET escola = '{Escolaselecionada.Nome}' WHERE escola= '{Escolaselecionada.Nome}';";

                command = CriaComandoSQL(commandstring);
                command.ExecuteNonQuery();

            }


            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }


            finally { conn.Close(); }
        }



        public void DeletaEscolaDB(Escola Escolaselecionada) 
        {
            try
            {
                string commandstring =
                    $"DELETE FROM escolas WHERE id = {Escolaselecionada.Id}; DELETE FROM alunos WHERE escola = '{Escolaselecionada.Nome}';";

                command = CriaComandoSQL(commandstring);
                command.ExecuteNonQuery();
            }


            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }


            finally { conn.Close(); }

        }
        


        // CRUD ALUNO
        public List<Aluno> ReadAluno() 
        {
            List<Aluno> listreturn = new List<Aluno>();
            try
            {
                string commandstring = "select * from alunos";
                
                command = CriaComandoSQL(commandstring);
                NpgsqlDataReader dr = command.ExecuteReader();

                if (dr.HasRows) // Preenche dr com a lista de Alunos
                {
                    while (dr.Read())
                    {
                        listreturn.Add(new Aluno(
                            dr.GetInt32(0),
                            dr.GetString(1),
                            dr.GetInt32(2),
                            dr.GetString(3),
                            dr.GetString(4))                            
                            );
                    }
                }
            }


            catch (Exception) //DÚVIDA DE SINTAXE!
            {
                throw;
            }

            finally { conn.Close(); }
            return listreturn;
        }
                   

        public void AddAlunoDB(Aluno alunocadastro) 
        {
            try
            {
                string commandstring =
                    "INSERT INTO alunos (nome, idade, serie, escola)" +
                    $"VALUES ('{alunocadastro.Nome}', {alunocadastro.Idade}, '{alunocadastro.Serie}', '{alunocadastro.Escola}');";

                command = CriaComandoSQL(commandstring);
                command.ExecuteNonQuery();
            }


            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }


            finally { conn.Close(); }
        }



        public void AtualizaAlunoDB(Aluno alunoselecionado) 
        {
            try
            {
                string commandstring =
                    $"UPDATE alunos SET nome = '{alunoselecionado.Nome}', idade = {alunoselecionado.Idade}, serie = '{alunoselecionado.Serie}', escola = '{alunoselecionado.Escola}' WHERE id = {alunoselecionado.Id};";

                command = CriaComandoSQL(commandstring);
                command.ExecuteNonQuery();
            }


            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }


            finally { conn.Close(); }
        }



        public void DeletaAlunoDB(Aluno alunoselecionado) 
        {
            try
            {
                string commandstring =
                    $"DELETE FROM alunos WHERE id = {alunoselecionado.Id}";

                command = CriaComandoSQL(commandstring);
                command.ExecuteNonQuery();
            }


            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }


            finally { conn.Close(); }
        }    
    }
}
