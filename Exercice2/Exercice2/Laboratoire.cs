using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercice2;

public class Laboratoire
{

    private int code;
    private int nb_chaises;
    private int nb_ordinateurs;
    private Personne directeur;


    public Laboratoire() { }

    public Laboratoire(int code, int nb_chaises, int nb_ordinateurs, Personne directeur)
    {
        this.code = code;
        this.nb_chaises = nb_chaises;
        this.nb_ordinateurs = nb_ordinateurs;
        this.directeur = directeur;
    }

    public int getNbOrdinateurs()
    {
        return this.nb_ordinateurs;
    }

    public Personne getDirecteur()
    {
        return this.directeur;
    }

    public string ViewLab()
    {
        return "lab : " + this.code + " nb : " + this.nb_chaises;
    }


}
