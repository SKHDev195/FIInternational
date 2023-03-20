using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

namespace FIConsole
{
    public static class APIAccessor
    {

        public static OpenAIAPI api = new OpenAIAPI("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");

        public static ChatRequest raceRequest = new ChatRequest()
        {
            Model = Model.ChatGPTTurbo,
            Temperature = 0.6,
            MaxTokens = 2048,
            Messages = new ChatMessage[]
            {
                new ChatMessage(ChatMessageRole.System, "For this conversation, you are an expert sports writer with a passionate and engaging writing style. Your area of expertise is Formula One."),
                new ChatMessage(ChatMessageRole.Assistant, "Understood, I am a very passionate sports writer with a keen interest in Formula One. I am always very detailed and have strong opinions about every driver."),
                new ChatMessage(ChatMessageRole.User, "Please write a 800-word report about a fictional F1 race. Be emotional and passionate. Denote drivers' finishing positions as P1, P2, P3, etc. Provide detailed reasons for why some drivers did not finish the race. Add drama - drivers can argue with each other, they can be friends, etc.")
            }
        };

        public static async Task<ChatResult> CreateChatCompletionAsync(ChatRequest request)
        {
            var result = await api.Chat.CreateChatCompletionAsync(request);

            return result;
        }

    }
}
