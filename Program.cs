using CRUD.DAO;
using CRUD.Mapeamento;
using CRUD.Utilitarios;

//Conexao.Conectar();

try
{
    Conexao.Conectar();

    AlunoDAO alunoDAO = new AlunoDAO();
    Aluno aluno = new Aluno("Welliton Giori", "043.366.062-77", new DateTime(2006, 01, 18), 'M', 1.81, "69981423642");
    aluno._id = 1;

    //alunoDAO.Cadastrar(aluno);
    //alunoDAO.Atualizar(aluno);
    foreach (Aluno a in alunoDAO.Selecionar("043"))
    {
        Console.WriteLine(a._nome);

    }
    
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}