using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class LesLabos
{

    private Laboratoire[] labs;
    private int nb_labos;

    public LesLabos(int N)
    {

        this.nb_labos = N;

        this.labs = new Laboratoire[N];

        for (int i = 0; i < N; i++)
        {
            this.labs[i] = new Laboratoire(N + 1, N * 2, N * 3, new Personne("nom"+N,N+N*2,"grade"));
        }

    }

    public LesLabos(Laboratoire[] tab,int N)
    {
        this.nb_labos = N;
        this.labs = tab;

    }


    public void Ajout(int p)
    {
        for (int i = 0; i < p; i++)
        {
            Console.WriteLine("Ajoute");
        }
    }

    public Laboratoire getLab(int pos)
    {
        return this.labs[pos];
    }


    public Laboratoire LePlusModerne()
    {
        int max_ord = 0;
        Laboratoire l=null;

        for (int i = 0; i < this.labs.Length; i++)
        {
            if (this.labs[i].getNbOrdinateurs() > max_ord)
            {
                l = this.labs[i];
                max_ord = l.getNbOrdinateurs();
            }
        }

        return l;

    }

    public bool DirecteurLabo(int Mat,out int pos)
    {
        for (int i = 0; i < this.labs.Length; i++)
        {
            if (this.labs[i].getDirecteur().getMatricule() == Mat)
            {
                pos = i;
                return true;
            }
        }

        pos = -1;
        return false;
    }


}
