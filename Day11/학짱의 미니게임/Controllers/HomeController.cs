using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using WebAlgorithm.Models;

namespace WebAlgorithm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult snailResult(int snailSize)
        {
            ViewBag.snailResult = snailSize;
            ViewBag.snail = SnailFunc(snailSize);
            return View();
        }

        public IActionResult Result(int size1)
        {
            ViewBag.Result = StarFunc(size1);
            return View();
        }

        private string[][] SnailFunc(int height)
        {
            int[][] array = new int[height][];
            for (int i = 0; i < height; i++)
            {
                array[i] = new int[height];
            }

            int num = 1;
            int row = 0, col = 0;

            while (num <= height * height)
            {
                while (col < height && array[row][col] == 0)
                {
                    array[row][col] = num;
                    col++;
                    num++;
                }
                col--;
                row++;

                while (row < height && array[row][col] == 0)
                {
                    array[row][col] = num;
                    row++;
                    num++;
                }
                row--;
                col--;

                while (col >= 0 && array[row][col] == 0)
                {
                    array[row][col] = num;
                    col--;
                    num++;
                }
                col++;
                row--;

                while (row >= 0 && array[row][col] == 0)
                {
                    array[row][col] = num;
                    row--;
                    num++;
                }
                row++;
                col++;
            }
            // 배열을 문자열 배열로 변환하여 반환
            string[][] result = new string[height][];
            for (int i = 0; i < height; i++)
            {
                result[i] = new string[height];
                for (int j = 0; j < height; j++)
                {
                    result[i][j] = array[i][j].ToString();
                }
            }
            return result;
        }

        private string[] StarFunc(int height)
        {
            string[] triangle = new string[height];

            for (int i = 0; i < height; i++)
            {
                string row = "";

                for (int j = 0; j < height - i - 1; j++)
                {
                    row += " ";
                }

                for (int j = 0; j < 2 * i + 1; j++)
                {
                    row += "*";
                }

                triangle[i] = row;
            }

            return triangle;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}