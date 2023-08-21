namespace Application;

/// <summary>
/// Representa um coordenador de jogo, adicionando, removendo e encontrando jogos para os usuarios
/// </summary>
public interface IGameCoordinator
{
    /// <summary>
    /// Obteem em qual ponte determinado usuario se encontra.
    /// retorna null se este usuario não estiver em nenhum jogo
    /// </summary>
    IGameBridge? Get(User user);
    /// <summary>
    /// atribui um jogo para um usuário.
    /// criando um jogo se necessário, ou colocando o jogador em um jogo com vaga.
    /// </summary>
    IGameBridge Assign(User user);

    /// <summary> Remove o jogador de qualquer jogo que ele esteja, terminando o jogo se o jogo ficar vazio. </summary>
    void Drop(User user);
}
