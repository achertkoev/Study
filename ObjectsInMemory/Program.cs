//CheckChar();
//CheckString();
CheckStruct();
//CheckArray();
//CheckObject();
//CheckList();

void CheckChar()
{
    char a = 'a';
    char b = 'b';
    char с = 'c';

    var ptr1 = AddressOfChar(ref a);
    var ptr2 = AddressOfChar(ref b);
    var ptr3 = AddressOfChar(ref с);
}

void CheckString()
{
    var str = "abcde";
    var ptrString = AddressOfString(str);
}

void CheckStruct()
{
    var struc = new SimpleStruc { a = 0xAA, b = 0xAB };
    var arrayStruct = new SimpleStruc[5] { new SimpleStruc { a = 0xAA, b = 0xAB }, default, default, default, default };
    var ptr = AddressOf(arrayStruct);
    for (byte i = 0; i < arrayStruct.Length; i++)
        arrayStruct[i] = new SimpleStruc { a = i, b = 0xAA | 0xAB };
}

void CheckArray()
{
    byte[] byteArray = new byte[5] { 1, 2, 3, 0, 0 };
    var ptrArray = AddressOf(byteArray);
    for (byte i = 0; i < byteArray.Length; i++)
        byteArray[i] = i;
}

void CheckList()
{
    var list = new List<int>() { 1, 2, 3 };
    var ptrArray = AddressOf(list);
    list.Add(4);
    list.Add(5);
    list.Add(6);
    list.Add(7);
    ptrArray = AddressOf(list);
}

void CheckObject()
{

}

unsafe IntPtr AddressOf(object o)
{
    TypedReference mk = __makeref(o);
    return **(IntPtr**)&mk;
}

unsafe IntPtr AddressOfString(string o)
{
    TypedReference mk = __makeref(o);
    return **(IntPtr**)&mk;
}

unsafe IntPtr AddressOfChar(ref char o)
{
    TypedReference mk = __makeref(o);
    return *(IntPtr*)&mk;
}

unsafe IntPtr AddressOfStruct(ref SimpleStruc o)
{
    TypedReference mk = __makeref(o);
    return *(IntPtr*)&mk;
}

struct SimpleStruc
{
    public byte a;
    public byte b;
}