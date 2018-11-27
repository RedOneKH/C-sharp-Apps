using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Personne
{


    private string nom;
    private int matricule;
    private string grade;

    public Personne() { }

    public Personne(string nom , int matricule , string grade)
    {
        this.nom = nom;
        this.matricule = matricule;
        this.grade = grade;
    }

    public int getMatricule()
    {
        return this.matricule;
    }
 

}
