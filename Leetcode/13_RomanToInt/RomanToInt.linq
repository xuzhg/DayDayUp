<Query Kind="Program" />

// O(n)

void Main()
{
	RomanToInt("I").Dump();
	RomanToInt("III").Dump();
	RomanToInt("IV").Dump();
	RomanToInt("LXXXIX").Dump(); // 89
	
	RomanToInt("XCIX").Dump(); // 99
	RomanToInt("MCMXXXIV").Dump(); // 1934
	
	try
	{
		RomanToInt("MCMXBXXIV").Dump(); // exception
	}
	catch(Exception e)
	{
		e.Dump(); 
	}
}

// You can define other methods, fields, classes and namespaces here
//  I = 1
// IV = 4
//  V = 5
// IV = 9
//  X = 10
// XL = 40
//  L = 50
// XC = 90
//  C = 100
// CD = 400
//  D = 500
// CM = 900
//  M = 1000
int RomanToInt(string s) 
{
        int result = 0;
        
        int length = s.Length;
        
        for (int i = 0; i < length; )
        {
            char ch = s[i++];
            switch(ch)
            {
                case 'I':
                    
                    if (i < length)
                    {
                        char next = s[i];
                        if (next == 'V')
                        {
                            result += 4;
                            i++;
                        }
                        else if (next == 'X')
                        {
                            result += 9;
                            i++;
                        }
                        else
                        {
                            result += 1;    
                        }                        
                    }
                    else
                    {
                        result += 1;
                    }
                    break;
                    
                case 'X':
                    if (i < length)
                    {
                        char next = s[i];
                        if (next == 'L')
                        {
                            result += 40;
                            i++;
                        }
                        else if (next == 'C')
                        {
                            result += 90;
							i++;
                        }
                        else
                        {
                            result += 10;
                        }
                    }
                    else
                    {
                        result += 10;
                    }
                    break;
                    
                case 'C':
                    if (i < length)
                    {
                        char next = s[i];
                        if (next == 'D')
                        {
                            result += 400;
                            i++;
                        }
                        else if (next == 'M')
                        {
                            result += 900;
							i++;
                        }
                        else
                        {
                            result += 100;
                        }
                    }
                    else
                    {
                        result += 100;
                    }
                    break;
                    
                case 'V':
                    result += 5;
                    break;
                
				case 'L':
                    result += 50;
                    break;
					
                case 'D':
                    result += 500;
                    break;
                    
                case 'M':
                    result += 1000;
                    break;
                    
                default:
                    throw new Exception($"Unknow char '{ch}'!");
            }
            
        }
        
        
        return result;
    }