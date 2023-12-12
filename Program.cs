// See https://aka.ms/new-console-template for more information
//Acacia Dodge, Chess, Oct 16

using System.Data.SqlTypes;
using System.Reflection;
using System.Text.Json;
//indexoutofrange 174,425,380,544,646
//jumping/killing not working correctly
Console.WriteLine("Checkers \nYou may move any piece one move diagonally forward if there is not a piece in that spot. To kill an opponent's piece, you must move diagonally one jump over it. After killing a piece, you can continue to jump over and kill oponents pieces if desired. If you reach the opposite side of the board your piece becomes a king and you can move in any diagonal direction. The player who kills all of the opponents pieces first wins. Player 1’s pieces are “o”’s, and “*”’s when they become kings. Player 2’s pieces are “c”’s and “+”’s when they are kings.  \nPress any key to begin");
Console.ReadKey(true);
Console.Clear();

string[,] Pieces= {{" ", "1", "2", "3", "4", "5", "6", "7", "8"},{"A", " ", "o", " ", "o", " ", "o", " ", "o"},{"B", "o", " ", "o", " ", "o", " ", "o", " "}, {"C", " ", " ", " ", " ", " ", " ", " ", " "},{"D", " ", " ", " ", " ", " ", " ", " ", " "},{"E", " ", " ", " ", " ", " ", " ", " ", " "},{"F", " ", " ", " ", " ", " ", " ", " ", " "},{"G", " ", "c", " ", "c", " ", "c", " ", "c"},{"H", "c", " ", "c", " ", "c", " ", "c", " "}};

int Player=1;





static void Print(ref string[,] Pieces)
{
for(int y=0;y<9;y++)
{
for(int x=0;x<9;x++)
{
if(x==0)
{
if(y==0||y==2||y==4||y==6||y==8)
{
Console.Write("\n");
Console.BackgroundColor=ConsoleColor.Gray;
Console.Write($"{Pieces[y, x]}");
}
else
{
Console.BackgroundColor=ConsoleColor.Black;
Console.Write($"\n{Pieces[y, x]}");
}
}
else
{
if (Console.BackgroundColor==ConsoleColor.Gray)
{
Console.BackgroundColor=ConsoleColor.Black;
Console.Write(Pieces[y,x]);
}
else if (Console.BackgroundColor==ConsoleColor.Black)
{
Console.BackgroundColor=ConsoleColor.Gray;
Console.Write(Pieces[y,x]);
};
};
};
};
};

int win=0;

int P1=0;
int P2=0;


static void Winner(ref string[,] Pieces, ref int win, int P1, int P2)
{
for(int y=1;y<7;y++)
{
for(int x=1;x<7;x++)
{
if(Pieces[y,x]=="o"||Pieces[y,x]=="*")
P1++;
else if(Pieces[y,x]=="c"||Pieces[y,x]=="+")
P2++;
if(y==8&&Pieces[y,x]=="o")
Pieces[y,x]="*";
if(y==1&&Pieces[y,x]=="c")
Pieces[y,x]="+";

};
};
if (P1==0)
{
win=2;

}
else if (P2==0)
{
win=1;

};
};

int[] SG=new int[4];





static void Jump(ref string[,] Pieces,ref int[] SG, ref int Player, int win, int P1, int P2)
{
    Console.Clear();
    Print(ref Pieces);
    Console.BackgroundColor=ConsoleColor.Black;
    int[] J={SG[2],SG[3]};
    Console.WriteLine("\nTo jump, input coordinates of where you want to go next(do not input coordinates of piece). If you wish to stop jumping, input H,8");
    string? je=Console.ReadLine();
    string[] JS=new string [2];
try{
JS=je!.Split(",");
}
catch(Exception)
{
    Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
}
if (JS[1]=="1"||JS[1]=="2"||JS[1]=="3"||JS[1]=="4"||JS[1]=="5"||JS[1]=="6"||JS[1]=="7"||JS[1]=="8"&&JS[0]=="A"||JS[0]=="B"||JS[0]=="C"||JS[0]=="D"||JS[0]=="E"||JS[0]=="F"||JS[0]=="G"||JS[0]=="H")
   {
    if (JS[0]=="A")
JS[0]="1";
else if (JS[0]=="B")
JS[0]="2";
else if (JS[0]=="C")
JS[0]="3";
else if (JS[0]=="D")
JS[0]="4";
else if (JS[0]=="E")
JS[0]="5";
else if (JS[0]=="F")
JS[0]="6";
else if (JS[0]=="G")
JS[0]="7";
else if (JS[0]=="H")
JS[0]="8";
else
Jump(ref Pieces,ref SG,ref Player, win, P1, P2);

   }
  else
  {
  Jump(ref Pieces,ref SG, ref Player, win, P1, P2); 
  }
  SG[0]=J[0];
  SG[1]=J[1];
  SG[2]=Convert.ToInt32(JS[0]);
  SG[3]=Convert.ToInt32(JS[1]);
   
   
    if(SG[2]==8&&SG[3]==8)
    {
        if(Player==1)
        {
            Player=2;
            Ask(ref Pieces, ref SG, Player, win);
        }
        else if(Player==2)
        {
            Player=1;
            Ask(ref Pieces, ref SG, Player, win);
        }
    }

    if(Player==1)
    {
        if(Pieces[SG[0],SG[1]]=="o")
        {
        if(SG[1]+2==SG[3]&&SG[0]+2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]-1,SG[3]-1]=="c"||Pieces[SG[2]-1,SG[3]-1]=="+"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]+1,SG[1]+1]=" ";
        Pieces[SG[2],SG[3]]="o";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);

    }
    else if(SG[1]-2==SG[3]&&SG[0]+2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]-1,SG[3]+1]=="c"||Pieces[SG[2]-1,SG[3]+1]=="+"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]+1,SG[1]-1]=" ";
        Pieces[SG[2],SG[3]]="o";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
    }
    else if(Pieces[SG[0],SG[1]]=="*")
    {
        if(SG[1]+2==SG[3]&&SG[0]+2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]-1,SG[3]-1]=="c"||Pieces[SG[2]-1,SG[3]-1]=="+"))
        {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]+1,SG[1]+1]=" ";
        Pieces[SG[2],SG[3]]="*";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);

    }
    else if(SG[1]-2==SG[3]&&SG[0]+2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]-1,SG[3]+1]=="c"||Pieces[SG[2]-1,SG[3]+1]=="+"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]+1,SG[1]-1]=" ";
        Pieces[SG[2],SG[3]]="*";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
    else if(SG[1]-2==SG[3]&&SG[0]-2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]+1,SG[3]+1]=="c"||Pieces[SG[2]+1,SG[3]+1]=="+"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]-1,SG[1]-1]=" ";
        Pieces[SG[2],SG[3]]="*";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
    else if(SG[1]+2==SG[3]&&SG[0]-2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]+1,SG[3]-1]=="c"||Pieces[SG[2]+1,SG[3]-1]=="+"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]-1,SG[1]+1]=" ";
        Pieces[SG[2],SG[3]]="*";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
    }
    }
    else if(Player==2)
    {
        if(Pieces[SG[0],SG[1]]=="c")
        {
        if(SG[1]-2==SG[3]&&SG[0]-2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]+1,SG[3]+1]=="o"||Pieces[SG[2]+1,SG[3]+1]=="*"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]-1,SG[1]-1]=" ";
        Pieces[SG[2],SG[3]]="c";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
    else if(SG[1]+2==SG[3]&&SG[0]-2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]+1,SG[3]-1]=="o"||Pieces[SG[2]+1,SG[3]-1]=="*"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]-1,SG[1]+1]=" ";
        Pieces[SG[2],SG[3]]="c";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
    }
    else if(Pieces[SG[0],SG[1]]=="+")
    {
        if(SG[1]+2==SG[3]&&SG[0]+2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]-1,SG[3]-1]=="o"||Pieces[SG[2]-1,SG[3]-1]=="*"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]+1,SG[1]+1]=" ";
        Pieces[SG[2],SG[3]]="+";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);

    }
    else if(SG[1]-2==SG[3]&&SG[0]+2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]-1,SG[3]+1]=="o"||Pieces[SG[2]-1,SG[3]+1]=="*"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]+1,SG[1]-1]=" ";
        Pieces[SG[2],SG[3]]="+";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
    else if(SG[1]-2==SG[3]&&SG[0]-2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]+1,SG[3]+1]=="o"||Pieces[SG[2]+1,SG[3]+1]=="*"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]-1,SG[1]-1]=" ";
        Pieces[SG[2],SG[3]]="+";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
    else if(SG[1]+2==SG[3]&&SG[0]-2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]+1,SG[3]-1]=="o"||Pieces[SG[2]+1,SG[3]-1]=="*"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]-1,SG[1]+1]=" ";
        Pieces[SG[2],SG[3]]="+";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
    }
    }
Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
}






static void Ask(ref string[,] Pieces,ref int[] SG, int Player,int win, int P1, int P2)
{
Console.Clear();
Print(ref Pieces);
Console.BackgroundColor=ConsoleColor.Black;
Console.WriteLine($"\nWrite the coordinates of the piece you want to move, then where to move it. Type a letter, then a number, place a comma in between with no spaces then press enter. For example: G,1 F,2\nPlayer {Player}:\n");

string? Start=Console.ReadLine();
string? End=Console.ReadLine();

string[] SO=new string[4];
string[] SS;
string[] SE;
try{
SS=Start!.Split(",");
SE=End!.Split(",");
}
catch(Exception)
{
    Ask(ref Pieces, ref SG, Player, win, P1, P2);
}


//checking for viable input
try{
if (SS[1]=="1"||SS[1]=="2"||SS[1]=="3"||SS[1]=="4"||SS[1]=="5"||SS[1]=="6"||SS[1]=="7"||SS[1]=="8"&&SS[0]=="A"||SS[0]=="B"||SS[0]=="C"||SS[0]=="D"||SS[0]=="E"||SS[0]=="F"||SS[0]=="G"||SS[0]=="H")
{
if (SE[1]=="1"||SE[1]=="2"||SE[1]=="3"||SE[1]=="4"||SE[1]=="5"||SE[1]=="6"||SE[1]=="7"||SE[1]=="8"&&SE[0]=="A"||SE[0]=="B"||SE[0]=="C"||SE[0]=="D"||SE[0]=="E"||SE[0]=="F"||SE[0]=="G"||SE[0]=="H")
{
 SO[0]=SS[0];
 SO[1]= SS[1];
 SO[2]= SE[0];
 SO[3]= SE[1];
if (SO[0]=="A")
SO[0]="1";
else if (SO[0]=="B")
SO[0]="2";
else if (SO[0]=="C")
SO[0]="3";
else if (SO[0]=="D")
SO[0]="4";
else if (SO[0]=="E")
SO[0]="5";
else if (SO[0]=="F")
SO[0]="6";
else if (SO[0]=="G")
SO[0]="7";
else if (SO[0]=="H")
SO[0]="8";
else
Ask(ref Pieces,ref SG, Player, win, P1, P2);

if (SO[2]=="A")
SO[2]="1";
else if (SO[2]=="B")
SO[2]="2";
else if (SO[2]=="C")
SO[2]="3";
else if (SO[2]=="D")
SO[2]="4";
else if (SO[2]=="E")
SO[2]="5";
else if (SO[2]=="F")
SO[2]="6";
else if (SO[2]=="G")
SO[2]="7";
else if (SO[2]=="H")
SO[2]="8";
else
Ask(ref Pieces,ref SG, Player, win, P1, P2);


}

else
{
    Ask(ref Pieces,ref SG, Player, win, P1, P2);
}
}
else
{
    Ask(ref Pieces,ref SG, Player, win, P1, P2);
}
}
catch(IndexOutOfRangeException)
{
    Ask(ref Pieces, ref SG, Player, win, P1, P2);
}
SG[0]=Convert.ToInt32(SO[0]);
SG[1]=Convert.ToInt32(SO[1]);
SG[2]=Convert.ToInt32(SO[2]);
SG[3]=Convert.ToInt32(SO[3]);
Move(ref Pieces, SG, ref Player, win, P1, P2);
}






static void Move(ref string[,] Pieces, int[] SG, ref int Player, int win, int P1, int P2)
{
//moving pieces
if(Player==1)
{
if(Pieces[SG[0],SG[1]]=="o")
{
    if(SG[1]+1==SG[3]&&SG[0]+1==SG[2]&&Pieces[SG[2],SG[3]]==" ")
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[2],SG[3]]="o";
        if (Player==1)
        Player=2;
        else if(Player==2)
        Player=1;
        Winner(ref Pieces, ref win, P1, P2);
        Ask(ref Pieces,ref SG, Player, win, P1, P2);

    }
    else if(SG[1]-1==SG[3]&&SG[0]+1==SG[2]&&Pieces[SG[2],SG[3]]==" ")
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[2],SG[3]]="o";
        if (Player==1)
        Player=2;
        else if(Player==2)
        Player=1;
        Winner(ref Pieces, ref win, P1, P2);
        Ask(ref Pieces,ref SG, Player, win, P1, P2);
    }
   
    else if(SG[1]+2==SG[3]&&SG[0]+2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]-1,SG[3]-1]=="c"||Pieces[SG[2]-1,SG[3]-1]=="+"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]+1,SG[1]+1]=" ";
        Pieces[SG[2],SG[3]]="o";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);

    }
    else if(SG[1]-2==SG[3]&&SG[0]+2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]-1,SG[3]+1]=="c"||Pieces[SG[2]-1,SG[3]+1]=="+"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]+1,SG[1]-1]=" ";
        Pieces[SG[2],SG[3]]="o";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
}
else if(Pieces[SG[0],SG[1]]=="*")
{
      if(SG[1]+1==SG[3]&&SG[0]+1==SG[2]&&Pieces[SG[2],SG[3]]==" ")
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[2],SG[3]]="*";
        if (Player==1)
        Player=2;
        else if(Player==2)
        Player=1;
        Winner(ref Pieces, ref win, P1, P2);
        Ask(ref Pieces,ref SG, Player, win);

    }
    else if(SG[1]-1==SG[3]&&SG[0]+1==SG[2]&&Pieces[SG[2],SG[3]]==" ")
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[2],SG[3]]="*";
        if (Player==1)
        Player=2;
        else if(Player==2)
        Player=1;
        Winner(ref Pieces, ref win, P1, P2);
        Ask(ref Pieces,ref SG, Player, win, P1, P2);
    }
   
    else if(SG[1]+2==SG[3]&&SG[0]+2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]-1,SG[3]-1]=="c"||Pieces[SG[2]-1,SG[3]-1]=="+"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]+1,SG[1]+1]=" ";
        Pieces[SG[2],SG[3]]="*";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);

    }
    else if(SG[1]+2==SG[3]&&SG[0]-2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]+1,SG[3]-1]=="c"||Pieces[SG[2]+1,SG[3]-1]=="+"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]-1,SG[1]+1]=" ";
        Pieces[SG[2],SG[3]]="*";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
    else if(SG[1]-1==SG[3]&&SG[0]-1==SG[2]&&Pieces[SG[2],SG[3]]==" ")
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[2],SG[3]]="*";
        if (Player==1)
        Player=2;
        else if(Player==2)
        Player=1;
        Winner(ref Pieces, ref win, P1, P2);
        Ask(ref Pieces,ref SG, Player, win, P1, P2);
    }
    else if(SG[1]+1==SG[3]&&SG[0]-1==SG[2]&&Pieces[SG[2],SG[3]]==" ")
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[2],SG[3]]="*";
        if (Player==1)
        Player=2;
        else if(Player==2)
        Player=1;
        Winner(ref Pieces, ref win, P1, P2);
        Ask(ref Pieces,ref SG, Player, win, P1, P2);
    }
    else if(SG[1]-2==SG[3]&&SG[0]-2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]+1,SG[3]+1]=="c"||Pieces[SG[2]+1,SG[3]+1]=="+"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]-1,SG[1]-1]=" ";
        Pieces[SG[2],SG[3]]="*";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
    else if(SG[1]-2==SG[3]&&SG[0]+2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]-1,SG[3]+1]=="c"||Pieces[SG[2]-1,SG[3]+1]=="+"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]+1,SG[1]-1]=" ";
        Pieces[SG[2],SG[3]]="*";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
}
}
else if(Player==2)
{
if(Pieces[SG[0],SG[1]]=="c")
{
    if(SG[1]-1==SG[3]&&SG[0]-1==SG[2]&&Pieces[SG[2],SG[3]]==" ")
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[2],SG[3]]="c";
        if (Player==1)
        Player=2;
        else if(Player==2)
        Player=1;
        Winner(ref Pieces, ref win, P1, P2);
        Ask(ref Pieces,ref SG, Player, win, P1, P2);
    }
    else if(SG[1]+1==SG[3]&&SG[0]-1==SG[2]&&Pieces[SG[2],SG[3]]==" ")
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[2],SG[3]]="c";
        if (Player==1)
        Player=2;
        else if(Player==2)
        Player=1;
        Winner(ref Pieces, ref win, P1, P2);
        Ask(ref Pieces,ref SG, Player, win, P1, P2);
    }
    else if(SG[1]-2==SG[3]&&SG[0]-2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]+1,SG[3]+1]=="o"||Pieces[SG[2]+1,SG[3]+1]=="*"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]-1,SG[1]-1]=" ";
        Pieces[SG[2],SG[3]]="c";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
    else if(SG[1]+2==SG[3]&&SG[0]-2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]+1,SG[3]-1]=="o"||Pieces[SG[2]+1,SG[3]-1]=="*"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]-1,SG[1]+1]=" ";
        Pieces[SG[2],SG[3]]="c";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
}
else if(Pieces[SG[0],SG[1]]=="+")
{
      if(SG[1]+1==SG[3]&&SG[0]+1==SG[2]&&Pieces[SG[2],SG[3]]==" ")
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[2],SG[3]]="+";
        if (Player==1)
        Player=2;
        else if(Player==2)
        Player=1;
        Winner(ref Pieces, ref win, P1, P2);
        Ask(ref Pieces,ref SG, Player, win, P1, P2);

    }
    else if(SG[1]-1==SG[3]&&SG[0]+1==SG[2]&&Pieces[SG[2],SG[3]]==" ")
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[2],SG[3]]="+";
        if (Player==1)
        Player=2;
        else if(Player==2)
        Player=1;
        Winner(ref Pieces, ref win, P1, P2);
        Ask(ref Pieces,ref SG, Player, win, P1, P2);
    }
   
    else if(SG[1]+2==SG[3]&&SG[0]+2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]-1,SG[3]-1]=="o"||Pieces[SG[2]-1,SG[3]-1]=="*"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]+1,SG[1]+1]=" ";
        Pieces[SG[2],SG[3]]="+";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);

    }
    else if(SG[1]+2==SG[3]&&SG[0]-2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]+1,SG[3]-1]=="o"||Pieces[SG[2]+1,SG[3]-1]=="*"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]-1,SG[1]+1]=" ";
        Pieces[SG[2],SG[3]]="+";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
    else if(SG[1]-1==SG[3]&&SG[0]-1==SG[2]&&Pieces[SG[2],SG[3]]==" ")
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[2],SG[3]]="+";
        if (Player==1)
        Player=2;
        else if(Player==2)
        Player=1;
        Winner(ref Pieces, ref win, P1, P2);
        Ask(ref Pieces,ref SG, Player, win, P1, P2);
    }
    else if(SG[1]+1==SG[3]&&SG[0]-1==SG[2]&&Pieces[SG[2],SG[3]]==" ")
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[2],SG[3]]="+";
        if (Player==1)
        Player=2;
        else if(Player==2)
        Player=1;
        Winner(ref Pieces, ref win, P1, P2);
        Ask(ref Pieces,ref SG, Player, win, P1, P2);
    }
    else if(SG[1]-2==SG[3]&&SG[0]-2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]+1,SG[3]+1]=="o"||Pieces[SG[2]+1,SG[3]+1]=="*"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[0]-1,SG[1]-1]=" ";
        Pieces[SG[2],SG[3]]="+";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
    else if(SG[1]-2==SG[3]&&SG[0]+2==SG[2]&&Pieces[SG[2],SG[3]]==" "&&(Pieces[SG[2]-1,SG[3]+1]=="o"||Pieces[SG[2]-1,SG[3]+1]=="*"))
    {
        Pieces[SG[0],SG[1]]=" ";
        Pieces[SG[2]+1,SG[3]-1]=" ";
        Pieces[SG[2],SG[3]]="+";
        Winner(ref Pieces, ref win, P1, P2);
        Jump(ref Pieces,ref SG, ref Player, win, P1, P2);
    }
}
}
Ask(ref Pieces,ref SG, Player, win, P1, P2);
}

//Actual code
while(win==0)
{
Ask(ref Pieces,ref SG, Player, win, P1, P2);
Move(ref Pieces, SG, ref Player, win, P1, P2);
}
Console.Clear();
if(win==1)
Console.WriteLine("Player 1 wins!");
else if(win==2)
Console.WriteLine("Player 2 wins!");