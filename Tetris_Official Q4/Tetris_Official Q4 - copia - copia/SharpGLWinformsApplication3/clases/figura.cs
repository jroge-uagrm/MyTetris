using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;

namespace SharpGLWinformsApplication3.clases
{
    public class figura
    {
        int [,,] m;
        int x,y,z;

        public figura() {
            x = y = z = 3;
            m=new int[x,y,z];
        }

        public int get(int i,int j,int k) {
            return m[i, j, k];
        }

        ///////esta bien///////

        public int maxDer() {
            int max = -1;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        if (m[j, i, k] == 1)
                        {
                            max = i;
                        }   
                    }                    
                }
            }
            return max;
        }

        public int maxIzq()
        {
            for (int i = 0; i > 0; i--)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        if (m[j, i, k] == 1)
                        {
                            return j;
                        }   
                    }
                }
            }
            return -1;
        }

        public int maxSup()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        if (m[i, j, k] == 1)
                        {
                            return i;
                        }
                    }
                }
            }
            return -1;
        }

        public int maxInf()
        {
            int max = -1;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        if (m[i, j, k] == 1)
                        {
                            max = i;
                        }
                    }
                }
            }
            return max;
        }

        public int max_Z() {
            int max = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        if(get(i,j,k)==1)
                        max = k;
                    }
                }
            }
            return max;
        }
        ////////RRRRRRRRRR//////////
       
        public void Choosefigures(int i) {
            m = new int[x, y, z];
            switch(i){
                case 0:{
                    m[0, 0, 1] = 1;
                    m[1, 0, 1] = 1;
                    m[2, 0, 1] = 1;
                    m[2, 1, 1] = 1;

//                    1   0   0
//                    1   0   0
//                    1   1   0

                }
                break;

                case 1:
                {
                    m[0, 0, 1] = 1;
                    m[0, 1, 1] = 1;
                    m[0, 2, 1] = 1;
                    m[1, 1, 1] = 1;
                    m[2, 1, 1] = 1;

//                    1   1   1
//                    0   1   0
//                    0   1   0
                }
                break;

                case 2:
                {
                    m[0, 1, 1] = 1;
                    m[1, 1, 1] = 1;
                    m[2, 1, 1] = 1;
//                    1   0   0
//                    1   0   0
//                    1   0   0
                }
                break;

                case 3:
                {
                    m[0, 0, 1] = 1;
                    m[0, 1, 1] = 1;
                    m[1, 1, 1] = 1;
                    m[1, 2, 1] = 1;

//                    1   1   0
//                    0   1   1
//                    0   0   0
                }
                break;

                case 4:
                {
                    m[0, 0, 1] = 1;
                    m[1, 0, 1] = 1;
                    m[0, 1, 1] = 1;
                    m[1, 1, 1] = 1;

//                    1   1   0
//                    1   1   0
//                    0   0   0
                }
                break;
                case 5:
                {
                    m[0, 1, 1] = 1;
                    m[1, 1, 1] = 1;
                    m[2, 0, 1] = 1;
                    m[2, 1, 1] = 1;
                    m[2, 2, 1] = 1;
                }
                break;
                case 6:
                {
                    m[0, 0, 0] = 1;
                    m[0, 0, 1] = 1;
                    m[0, 0, 2] = 1;
                    //                    1   0   0
                    //                    1   0   0
                    //                    1   0   0
                }
                break;
        }
        }

        public void randomFig() {
            Random r = new Random();
            int r1=(int)r.Next(6);
            Choosefigures(r1);
        }

        public void cargar() {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    m[i, j, 0] = 0;
                }
            }
        }

        public void dibujar(OpenGL gl, cubo c) {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        if (m[i, j, k] == 1)
                        {
                            gl.Color(0.2f,0.4f,0.6f);
                            c.draw(gl, i, j, k);
                        }   
                    }
                }
            }
        }

        public void rotarX()
        {
            int[, ,] n = new int[3, 3, 3];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        n[i, k, 2 - j] = m[i, j, k];
                    }
                }
            }
            m = n;
        }

        public void rotarY()
        {
            int[, ,] n = new int[3, 3, 3];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        n[k, j, 2 - i] = m[i, j, k];
                    }
                }
            }
            m = n;
        }

        public void rotarZ()
        {
            int[, ,] n = new int[3, 3, 3];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        n[j, 2 - i, k] = m[i, j, k];
                    }
                }
            }
            m = n;
        }

        public void rotarNegX()
        {
            int[, ,] n = new int[3, 3, 3];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        n[i, 2 - k, j] = m[i, j, k];
                    }
                }
            }
            m = n;
        }

        public void rotarNegY()
        {
            int[, ,] n = new int[3, 3, 3];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        n[2 - k, j, i] = m[i, j, k];
                    }
                }
            }
            m = n;
        }

        public void rotarNegZ()
        {
            int[, ,] n = new int[3, 3, 3];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        n[2 - j, i, k] = m[i, j, k];
                    }
                }
            }
            m = n;
        }


    }
}
