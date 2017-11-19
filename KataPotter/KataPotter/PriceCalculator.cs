using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPotter
{
    public class PriceCalculator
    {
        const double BOOKPRICE = 8;
        const double PERCENT2BOOKS = 0.95;
        const double PERCENT3BOOKS = 0.9;
        const double PERCENT4BOOKS = 0.8;
        const double PERCENT5BOOKS = 0.75;

        public double GetPrice(int[] books)
        {
            int[] bookCount = CountBooks(books);
            int[] packages = GetPackages(books);
            packages = OptimizePackages(packages);
            double sumPrice = 0;

            foreach(int numberDifferentBooks in packages)
            {
                sumPrice += GetPackagePrice(numberDifferentBooks);
            }

            return sumPrice;
        }

        private int[] CountBooks(int[] books)
        {
            int[] bookCount = new int[5];
            foreach(int book in books)
            {
                bookCount[book]++;
            }

            return bookCount;
        }

        public int[] GetPackages(int[] books)
        {
            List<int> packages = new List<int>();
            int lastBook = books[0];
            int i = 0;

            foreach (int book in books)
            {
                if (book != lastBook)
                {
                    i = 0;
                }

                if (packages.Count > i)
                {
                    packages[i]++; // add to existing package
                }
                else
                {
                    packages.Add(1); // package does not yet exist --> create new
                }

                lastBook = book;
                i++;
            }

            return packages.ToArray();
        }

        // 1. 2 times 4 different books is better (cheaper) than 5 different books and 3 different books. --> optimize
        // 2. 4 diff books and 2 diff books is better than 2 times 3 different books --> no optimization
        private int[] OptimizePackages(int[] packages)
        {
            // find ..., 5, 3, ... --> ..., 4, 4, ... // this is only valid for the give discounts
            for (int i = 0; i < packages.Length - 1; i++)
            {
                if (i < packages.Length && packages[i] == 5 && packages[i+1] == 3)
                {
                    packages[i] = 4;
                    packages[i + 1] = 4;
                }
            }
            return packages;
        }

        private double GetPackagePrice(int numberOfDifferentBooksInPackage)
        {
            double price = numberOfDifferentBooksInPackage * BOOKPRICE * GetDiscount(numberOfDifferentBooksInPackage);
            return price;
        }

        private double GetDiscount(int numberDifferentBooks)
        {
            switch (numberDifferentBooks)
            {
                case 2:
                    return PERCENT2BOOKS;
                case 3:
                    return PERCENT3BOOKS;
                case 4:
                    return PERCENT4BOOKS;
                case 5:
                    return PERCENT5BOOKS;
                default:
                    return 1;
            }
        }
    }
}
