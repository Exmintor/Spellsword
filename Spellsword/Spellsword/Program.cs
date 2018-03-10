using System;

namespace Spellsword
{
#if WINDOWS || LINUX // Lol we don't support MAC here, scrub
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new SpellswordGame())
                game.Run();
        }
    }
#endif
}
