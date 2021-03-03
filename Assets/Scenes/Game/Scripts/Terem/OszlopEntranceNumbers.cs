namespace ECASimulator.Terem
{
    public static class OszlopEntranceNumbers
    {

        public static int[] Generate(int oszlopszam,int entranceszam)
         {
             if (entranceszam == 0)
             {
                 int[] myNum = {0};
                 return myNum;
             }
            if (oszlopszam==1)
            { int[] myNum = {0};
                return myNum;
            }else if (oszlopszam == 2)
            {
                if (entranceszam==1)
                {int[] myNum = {1};
                    return myNum;
                }
            }
            
            else if (oszlopszam == 3)
            {
                 if (entranceszam==2)
                {int[] myNum = {1,3};
                    return myNum;
                }
            }
            else if (oszlopszam == 4)
            {
                if (entranceszam==1)
                {int[] myNum = {2};
                    return myNum;
                }else if (entranceszam==3)
                {int[] myNum = {1,3};
                    return myNum;
                }
            }
            else if (oszlopszam == 6)
            {if (entranceszam==1)
                {int[] myNum = {3};
                    return myNum;
                }else if (entranceszam==2)
                {int[] myNum = {2,5};
                    return myNum;
                }else if (entranceszam==5)
                {int[] myNum = {1,2,4,6,8};
                    return myNum;
                }
            }else if (oszlopszam == 8)
            {if (entranceszam==1)
                {int[] myNum = {4};
                    return myNum;
                }else if (entranceszam==3)
                {int[] myNum = {2,5,8};
                    return myNum;
                }else if (entranceszam==7)
                {int[] myNum = {1,2,4,6,8,10};
                    return myNum;
                }
            }
            int[] myNum2 = {0};
            return myNum2;
        }
     
        
        
        
    }
}