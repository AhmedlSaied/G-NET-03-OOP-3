using System;

namespace OOPAssignment03
{
    #region PART 01: THEORETICAL ANSWERS

    /*
     * Q1 : Identification of OOP Relationships:
     * a) Composition — Departments cannot exist independently of the University.
     * b) Association — Driver uses Car without owning its lifecycle.
     * c) Inheritance (IS-A) — Dog inherits from Animal.
     * d) Aggregation — Players exist independently if Team is deleted.
     * e) Dependency — Method relies on Logger temporarily inside call execution scope.
     * 
     * Q2 : Access Modifiers and Sealed Keyword Answers:
     * a) Yes, a child class in another assembly can access a protected field inside its derived class logic. 
     *    No, it cannot be accessed directly via an object instance from the outside.
     * 
     * b) protected internal: Accessible anywhere within the SAME assembly OR in derived classes outside the assembly (OR logic).
     *    private protected: Accessible ONLY inside derived classes that are WITHIN the same assembly (AND logic).
     * 
     * c) On Class: Prevents other classes from inheriting from it.
     *    On Method: Prevents derived classes from overriding the method further (must be used on an overridden virtual/abstract method).
     * 
     * d) Yes. Sealed only prevents inheritance; standard instantiation (`new`) works as normal unless its constructor is private.
     */

    #endregion
    #region SUPPORTING CLASSES & COMPOSITION

    public class Projector
    {
        public void Start() => Console.WriteLine("Projector started.");
        public void Stop() => Console.WriteLine("Projector stopped.");
    }

    #endregion
    #region BASE TICKET CLASS

    public class Ticket
    {
        private static int totalTickets = 0;

        private string movieName = "Unknown";
        private decimal price = 1m;

        public int TicketId { get; }

        public string MovieName
        {
            get => movieName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    movieName = value;
                }
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (value > 0)
                {
                    price = value;
                }
            }
        }

        public decimal PriceAfterTax => Price * 1.14m;

        public Ticket(string movieName, decimal price)
        {
            TicketId = ++totalTickets;
            MovieName = movieName;
            Price = price;
        }

        public static int GetTotalTickets() => totalTickets;

        public override string ToString()
        {
            return $"Ticket #{TicketId} | {MovieName} | Price: {Price:F0} EGP | After Tax: {PriceAfterTax:F2} EGP";
        }
    }

    #endregion
    #region CHILD TICKET CLASSES

    public class StandardTicket : Ticket
    {
        public string SeatNumber { get; set; }

        public StandardTicket(string movieName, decimal price, string seatNumber)
            : base(movieName, price)
        {
            SeatNumber = seatNumber;
        }

        public override string ToString()
        {
            return $"{base.ToString()} | Seat: {SeatNumber}";
        }
    }

    public class VIPTicket : Ticket
    {
        public bool LoungeAccess { get; set; }
        public decimal ServiceFee { get; } = 50m;

        public VIPTicket(string movieName, decimal price, bool loungeAccess)
            : base(movieName, price)
        {
            LoungeAccess = loungeAccess;
        }

        public override string ToString()
        {
            string loungeStr = LoungeAccess ? "Yes" : "No";
            return $"{base.ToString()} | Lounge: {loungeStr} | Service Fee: {ServiceFee:F0} EGP";
        }
    }

    public class IMAXTicket : Ticket
    {
        public bool Is3D { get; set; }

        public IMAXTicket(string movieName, decimal price, bool is3D)
            : base(movieName, price + (is3D ? 30m : 0m))
        {
            Is3D = is3D;
        }

        public override string ToString()
        {
            string is3DStr = Is3D ? "Yes" : "No";
            return $"{base.ToString()} | IMAX 3D: {is3DStr}";
        }
    }

    #endregion
    #region CINEMA CLASS

    public class Cinema
    {
        public string CinemaName { get; set; }
        private readonly Projector projector;
        private readonly Ticket[] tickets = new Ticket[20];

        public Cinema(string cinemaName)
        {
            CinemaName = cinemaName;
            projector = new Projector(); // Composition (Lifetime bound to Cinema)
        }

        public bool AddTicket(Ticket t)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i] == null)
                {
                    tickets[i] = t;
                    return true;
                }
            }
            return false;
        }

        public void PrintAllTickets()
        {
            Console.WriteLine("========== All Tickets ==========");
            for (int i = 0; i < tickets.Length; i++)
            {
                if (tickets[i] != null)
                {
                    Console.WriteLine(tickets[i]);
                }
            }
        }

        public void OpenCinema()
        {
            Console.WriteLine("========== Cinema Opened ==========");
            projector.Start();
        }

        public void CloseCinema()
        {
            Console.WriteLine("\n========== Cinema Closed ==========");
            projector.Stop();
        }
    }

    #endregion
}