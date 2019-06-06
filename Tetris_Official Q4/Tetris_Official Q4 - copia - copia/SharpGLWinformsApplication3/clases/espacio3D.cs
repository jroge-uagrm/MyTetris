using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpGLWinformsApplication3.clases
{

    public class espacio3D
    {
        int[, ,] m;
        int x, y, z;
        public espacio3D(int xx, int yy, int zz)
        {
            x = xx; y = yy; z = zz;
            m = new int[xx, yy, zz];
        }

        public int getX() {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public int getZ()
        {
            return z;
        }

        public void setX(int xx) {
            x = xx;
        }

        public void setY(int yy) {
            y = yy;
        }

        public void setZ(int zz) {
            z = zz;
        }

        public void add(int xx,int yy,int zz){
            m[xx, yy, zz] = 1;
        }

        public int get(int xx,int yy,int zz) { 
            return m[xx,yy,zz];
        }

        public void less(int xx,int yy,int zz){
            m[xx, yy, zz] = 0;
        }

        public void addFig(figura f,int xx,int yy,int zz) {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (f.get(i, j, k) == 1)
                        {
                            add(i + xx, j + yy, k+zz);
                        }   
                    }                   
                }
            }
        }

        public bool avance3(figura f, int xx, int yy, int zz)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        try
                        {
                            if (f.get(i, j, k) == 1 && get(i + xx, j + yy, k + zz) == 1)
                            {
                                return false;
                            }
                        }
                        catch (Exception)
                        {
                            return false;
                            throw;
                        }
                        
                    }
                }
            }
            return true;
        }

        public void cortar(int k) {

            for (int h = k; h > 0; h--){
                for (int i = 0; i < x; i++){
                    for (int j = 0; j < y; j++){
                        m[i, j, k - 1] = m[i, j, k - 2];
                    }
                }
            }
        }

        public void avanzar() {
            for (int h = z; h > 0; h--)
            {
                if(esta_llena(h-1)){
                    cortar(h);
                    //h++;
                }
            }
        }

        public bool esta_llena(int k) {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if(get(i,j,k)==0){
                        return false;
                    }
                }
            }
            return true;
        }

        public bool RotarEnX(figura f, int xx, int yy, int zz)
        {
            f.rotarX();
            bool b = avance3(f, xx, yy, zz);
            f.rotarNegX();
            return b;
        }

        public bool RotarEnNegX(figura f, int xx, int yy, int zz)
        {
            f.rotarNegX();
            bool b = avance3(f, xx, yy, zz);
            f.rotarX();
            return b;
        }

        public bool RotarEnY(figura f, int xx, int yy, int zz)
        {
            f.rotarY();
            bool b = avance3(f, xx, yy, zz);
            f.rotarNegY();
            return b;
        }

        public bool RotarEnNegY(figura f, int xx, int yy, int zz)
        {
            f.rotarNegY();
            bool b = avance3(f, xx, yy, zz);
            f.rotarY();
            return b;
        }

        public bool RotarEnZ(figura f, int xx, int yy, int zz)
        {
            f.rotarZ();
            bool b = avance3(f, xx, yy, zz);
            f.rotarNegZ();
            return b;
        }

        public bool RotarEnNegZ(figura f, int xx, int yy, int zz)
        {
            f.rotarNegZ();
            bool b = avance3(f, xx, yy, zz);
            f.rotarZ();
            return b;
        }
    }
}
