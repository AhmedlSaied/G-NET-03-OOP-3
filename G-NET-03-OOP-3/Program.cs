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
}