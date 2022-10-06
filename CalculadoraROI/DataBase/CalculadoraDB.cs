using CalculadoraROI.Models;
using MySql.Data.MySqlClient;

namespace CalculadoraROI.DataBase
{
    public class CalculadoraDB
    {
        private readonly MySqlConnection _connection;

        public CalculadoraDB(MySqlConnection connection)
        {
            _connection = connection;
        }

        public void Inserir(Calculadora calculadora)
        {
            try
            {
                string queryString = "INSERT INTO calculadora (Nome, Email, Empresa, Segmento, AreaAtuacao, Onboarding, ConsultaMes, TicketMedio, ResultadoRoi, DataHoraCalculo) VALUES (@Nome, @Email, @Empresa, @Segmento, @AreaAtuacao, @Onboarding, @ConsultaMes, @TicketMedio, @ResultadoRoi, @DataHoraCalculo)";
                MySqlCommand command = new MySqlCommand(queryString, _connection);

                command.Parameters.AddWithValue("@Nome", calculadora.Nome);
                command.Parameters.AddWithValue("@Email", calculadora.Email);
                command.Parameters.AddWithValue("@Empresa", calculadora.Empresa);
                command.Parameters.AddWithValue("@Segmento", calculadora.Segmento);
                command.Parameters.AddWithValue("@AreaAtuacao", calculadora.AreaAtuacao);
                command.Parameters.AddWithValue("@Onboarding", calculadora.Onboarding);
                command.Parameters.AddWithValue("@ConsultaMes", calculadora.ConsultaMes);
                command.Parameters.AddWithValue("@TicketMedio", calculadora.TicketMedio);
                command.Parameters.AddWithValue("@ResultadoRoi", calculadora.ResultadoRoi);
                command.Parameters.AddWithValue("@DataHoraCalculo", DateTime.Now);

                _connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao incluir o calculadora - " + ex.Message);
            }
            finally
            {
                _connection.Close();
                _connection.Dispose();
            }

        }

    }
}
