using SQLite;

namespace Pacientes.Forms.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}