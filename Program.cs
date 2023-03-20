using FIConsole;

using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

class Program
{
    public static void Main(string[] args)
    {
        GameController gameController = new GameController();

        gameController.RunChampionship();


    }
}