﻿using Project_EF_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_EF_Core.Helpers
{
    public class ItemsHelper
    {
        public static int MultipleChoice<T>(bool canCancel, List<T> items, bool IsMenu = false, string message = null,
            int spacingPerLine = 20, int optionsPerLine = 3, int startX = 2, int startY = 1) where T : IShow<int>, new()
        {
            //Если это стандарстное меню, то
            //добавляем в начало списка пункт - "Back", для возвращения назад по меню
            if (IsMenu)
            {
                items.Insert(0, new T() { Id = 0, Value = "{...Back}" });
            }
            int currentSelection = 0;
            int currentId = 0;
            ConsoleKey key;
            Console.CursorVisible = false;

            do
            {
                Console.Clear();
                //Проверяем усть ли сообщение и выводим
                if (message is not null)
                {
                    Console.WriteLine(message);
                }
                if (currentSelection >= items.Count)
                {
                    currentSelection--;
                }
                for (int i = 0; i < items.Count; i++)
                {
                    Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);
                    if (i == currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        currentId = items[i].Id;
                    }

                    Console.Write(items[i].Value);
                    Console.ResetColor();
                }
                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            currentSelection--;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % optionsPerLine < optionsPerLine - 1)
                            {
                                currentSelection++;
                            }
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                                currentSelection -= optionsPerLine;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < items.Count)
                                currentSelection += optionsPerLine;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                                return 0;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;
            Console.WriteLine("\n");
            return currentId;
        }
    }
}
