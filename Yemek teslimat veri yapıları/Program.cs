using System;
using System.Collections.Generic;
using System.Collections;
namespace Project2
{
    class Mahalle //Mahalle sınıfı oluşturulmuştur.
    {
        //Mahalle sınıfının değişkenleri ve get set metotları tanımlanmıştır. Mahallenin adı ve teslimat nesnesi tipinde veri alan generic liste.
        public string mahalleAdı { get; set; }
        public List<Teslimat> genericList { get; set; }
        public Mahalle(string mahalleAdı) //Constructer metodu.
        {
            this.mahalleAdı = mahalleAdı;
            genericList = new List<Teslimat>();
        }
        public override string ToString() 
        {
            string aa = "";
            foreach (Teslimat t in genericList)
                aa = aa + t.ToString()+ "\n";
            return ""+ mahalleAdı+"\n"+ aa + "\n";
        }
    }
    //Teslimat sınıfı oluşturulmuştur.
    class Teslimat
    {
        public string yemekAdı; //Teslimat sınıfı nesnelerinin yemek adı ve yemek adı değişkenleri tanımanmıştır.
        public int yemekAdedi;

        public Teslimat(string yemekAdı, int yemekAdedi) //COnstructer metodu.
        {
            this.yemekAdı = yemekAdı;
            this.yemekAdedi = yemekAdedi;   
        }
        public override string ToString()
        {
            return " "+ yemekAdı+ ", "+ yemekAdedi;
        }
    }
    //Yığıt sınıfı tanımlanmıştır. Veriler sona eklenir ve sondan veri çıkarılır.
    class Stack
    {
        private int maxSize; //Yığıtın boyutu
        private Mahalle[] stackArray; //Verileri tutmak için mahalle tipinde veri alan dizi.
        private int top; //Yığıtın son verisi

        public Stack(int s) //Constructer
        {
            maxSize = s;
            stackArray = new Mahalle[maxSize];
            top = -1; //Başta veri olmadığı için -1 değeri atanmıştır.
        }
        public void push(Mahalle mahalle) //önce son veri indisini arttırır, sonra parametre olarak gelen nesneyi yığıt dizisinin sonuna ekler.
        {
            stackArray[++top] = mahalle;
            
        }
        public Mahalle pop() //önce dizinin son verisini döndürür, sonra son veriyinin indisini bir azaltarak günceller.
        {
            return stackArray[top--];   
        }
        public Mahalle peek() //Son elemanı döndürür.
        {
            return stackArray[top];
        }
        public bool isEmpty() //yığıt boş ise true, değilse false döndürür.
        {
            return top == -1;
        } 
        public bool isFull() //Yığıt dolu ise true, boş ise false döndürür.
        {
            return top == maxSize-1;
        }
    }
    class Queue
    {
        private int maxSize;
        private Mahalle[] queArray;
        private int rear;  //kuyruğun sonundaki elemanı tutar.
        private int front; //kuyruğun başındaki elemanı tutar.
        private int nItems; //kuyruktaki item sayısı.

        public Queue(int s)
        {
            maxSize = s;
            queArray = new Mahalle[maxSize]; //Mahalle tipinde nesne verilerini tutacak dizi.
            front = 0;
            rear = -1;
            nItems = 0;
        }
        public void insert(Mahalle mahalle)
        {
            if (rear == maxSize - 1) //kuyruk dolduysa 
                rear = -1;
            queArray[++rear] = mahalle;
            nItems++;
        }
        public Mahalle remove()
        {
            Mahalle temp = queArray[front++];
            if (front == maxSize) //kuyrukta başka eleman kalmadıysa
                front = 0;
            nItems--;
            return temp;
        }
        public Mahalle peekFront() //Kuyruğun başını döndürür.
        {
            return queArray[front];
        }
        public bool isEmpty() // kuyruk boşsa true döndürür.
        {
            return nItems == 0;
        }
        public bool isFull() // kuyruk doluysa true döndürür.
        {
            return nItems == maxSize;
        }
        public int size() //kuyrukta kaç eleman olduğunu döndürür.
        {
            return nItems;
        }
    }
    class PriorityQueue //Öncelikli kuyruk sınıfı oluşturulmuştur. Ekleme işlemi normal kuyruktaki gibi sona yapılır. Veriler azalan sırada kuyruktan çıkarılır.
    {
        private int maxSize;
        private List<Mahalle> pqArray; //Mahalle tipindeki nesne verilerini tutmak için generic liste.
        private int rear; //Son veri indeksi
        private int nItems; //Toplam veri sayısı
        private int current; //En büyük veriyi bulmak için tanımlanmış indeks.
        private int maxTeslimat; //En büyük veriyi bulmak için tanımlanmış indeks.
        public PriorityQueue(int s)
        {
            maxSize=s;
            pqArray = new List<Mahalle>(maxSize);
            rear = -1;
            nItems = 0;
    }
        public void insert(Mahalle mahalle)
        {
            if (rear == maxSize - 1) //kuyruk dolduysa
                rear = -1;
            pqArray.Add(mahalle);
            rear++;
            nItems++;
        }
        public Mahalle remove()
        {
            maxTeslimat = -1; //maximum teslimat sayısı için tutalan sayı. ilk değeri -1.
            current = 0; //maximum teslimat bulmak için tutulan index.
            Mahalle temp; //Çıkarılacak veriyi tutmak için tanımlanan değişken.
            for (int i = 0; i < pqArray.Count; i++) //Listedeki bütün veriler dolaşılacak veri teslimat sayısı en büyük olan mahalle bulunacaktır.
            {
                if(pqArray[i].genericList.Count> maxTeslimat)
                {
                    maxTeslimat = pqArray[i].genericList.Count;
                    current = i; //Çıkarılacak verinin indeksi
                }
            }
            temp = pqArray[current]; //Çıkarılacak veri değişkene atandı.
            pqArray.RemoveAt(current); //Veri indeks ile çıkarıldı.
            nItems--; //Veri sayısı güncellendi.
            return temp; //Çıkarılan veri döndürüldü.
        }
        public bool isEmpty()
        {
            return nItems == 0;
        }
    }
    class IntPriorityQueue //int tipinde verilerden oluşan öncelikli kuyruk. Veriler artan sırada silenecek.
    {
        private int maxSize;
        private List<int> pqArray; //Verileri tutacak generic list
        private int rear; //Kuyruğun son verisinin indeksi
        private int nItems; //Veri sayısı
        private int current; //minimum değere sahip veriyi bulmak için atanan değişken.
        private int minÜrün; //minimum değere sahip veriyi bulmak için atanan değişken. 

        public IntPriorityQueue(int s) //Constructer
        {
            maxSize = s;
            pqArray = new List<int>(maxSize);
            rear = -1;
            nItems = 0;
        }
        public void insert(int sayı)
        {
            if (rear == maxSize - 1) //Liste dolduysa
                rear = -1;
            pqArray.Add(sayı);
            rear++;
            nItems++;

        }
        public int remove()
        {
            minÜrün = pqArray[0]; //minimum teslimat sayısı için tutalan sayı. ilk değeri dizideki birinci verinin değeri.
            current = 0; //minimum teslimat bulmak için tutulan index.
            int temp;
            for (int i = 1; i < pqArray.Count; i++) //Listedeki bütün veriler dolaşılacak ve minimum olan bulunacak.
            {
                if (pqArray[i] < minÜrün)
                {
                    minÜrün = pqArray[i];
                    current = i; //minimum verinin indeksi
                }
            }
            temp = pqArray[current]; //minimum verinin değeri değişkene atandı.
            pqArray.RemoveAt(current); //Minimum değere sahip veri listeden çıkarıldı.
            nItems--; //Veri sayısı güncellendi.
            return temp; //Çıkarılan veri döndürüldü
        }
        public bool isEmpty()
        {
            return nItems == 0;
        }
    }
    class IntQueue
    {
        private int maxSize;
        private int[] intQueueArray;
        private int rear;  //kuyruğun sonundaki elemanı tutar.
        private int front; //kuyruğun başındaki elemanı tutar.
        private int nItems; //kuyruktaki item sayısı.

        public IntQueue(int s)
        {
            maxSize = s;
            intQueueArray = new int[maxSize];
            front = 0;
            rear = -1;
            nItems = 0;
        }
        public void insert(int sayı)
        {
            if (rear == maxSize - 1) //kuyruk dolduysa 
                rear = -1;
            intQueueArray[++rear] = sayı;
            nItems++;
        }
        public int remove()
        {
            int temp = intQueueArray[front++];
            if (front == maxSize) //kuyrukta başka eleman kalmadıysa
                front = 0;
            nItems--;
            return temp;
        }
        public int peekFront() //Kuyruğun başını döndürür.
        {
            return intQueueArray[front];
        }
        public bool isEmpty() // kuyruk boşsa true döndürür.
        {
            return nItems == 0;
        }
        public bool isFull() // kuyruk doluysa true döndürür.
        {
            return nItems == maxSize;
        }
        public int size() //kuyrukta kaç eleman olduğunu döndürür.
        {
            return nItems;
        }
    }
    internal class Program
    {
        
        
        static void Main(string[] args)
        {
            Random random = new Random();
            //Bileşik veri yapısına eklenecek verileri tutan diziler.
            string[] mahalleAdı = { "Özkanlar", "Evka 3", "Atatürk", "Erzene", "Kazımdirik", "Mevlana", "Doğanlar", "Ergene" };
            int[] teslimatSayısı = { 5, 2, 7, 2, 7, 3, 0, 1 };
            string[] yemekListesi = { "Börek", "Pilav", "Türlü", "Pizza", "Simit", "Kızartma", "Hamburger", "Lazanya", "Köfte", "Mücver", "Nohut", "Döner", "Makarna", "Çorba", "Tavuk Sote", "Et Sote", "Kebap", "Kavurma", "Şırdan", "Kokoreç", "Ciğer", "Kumru", "Erişte", "Tost", "Dürüm", "Poğaça", "Pide" };
            int[] ürünAdetleri = { 6, 7, 2, 1, 12, 5, 3, 7, 4, 2 };//4. soru için kullanılacak dizi. Müşterilerin ürün adetleri
            ArrayList motoKurye = new ArrayList(); //Bileşik veri yapısının dinamik dizisi tanımlandı.
            int toplamTeslimat=0; //TOplam teslimat sayısı sayacı. İlk değeri 0.
            Stack stack = new Stack(mahalleAdı.Length); //Yığıt nesnesi yaratıldı.
            Queue queue = new Queue(mahalleAdı.Length);//Kuyruk nesnesi yaratıldı.
            PriorityQueue priorityQueue = new PriorityQueue(mahalleAdı.Length); //Öncelikli kuyruk nesnesi yaratıldı.
            IntQueue intQueue = new IntQueue(ürünAdetleri.Length); //İnt tipinde veriler alan kuyruk nesnesi yaratıldı.
            IntPriorityQueue intPriorityQueue = new IntPriorityQueue(ürünAdetleri.Length); //İnt tipinde veriler alan öncelikli kuyruk nesnesi yaratıldı.
            int işlemTamamlanmaSüreleri = 0; //Her müşterinin işlem süresini bulan sayaç tanımlandı ilk değeri 0.
            int toplamİşlemTamamlanmaSüreleri = 0; //Müşterilerin toplam işlem süresini bulan sayaç tamamlandı ilk değeri 0.
            //Bİleşik veri yapısı oluşturan for döngüleri. Verileri listelere istenilen şekilde ekler.
            for (int i = 0; i < mahalleAdı.Length; i++) //mahalle sayısı kadar dönecek.
            {
                Mahalle mahalle = new Mahalle(mahalleAdı[i]); //Mahalle nesnesi üretildi.
                
                for (int j = 0; j < teslimatSayısı[i]; j++) //Mahalleye yapılacak teslimat sayısı kadar dönecek for döngüsü.
                {
                    int yemekİndex = random.Next(0,yemekListesi.Length); //Yemek listesinden random yemek seçilmesi için index değeri random atandı.
                    int yemekAdedi = random.Next(1,50); //Yemek adedi 1'le 50 arasında random değer atandı. 
                    Teslimat teslimat = new Teslimat(yemekListesi[yemekİndex], yemekAdedi); //Random oluşturulan yemek ve adediyle teslimat nesnesi oluşturuldu.
                    mahalle.genericList.Add(teslimat); //Mahallenin teslimatları generic liste eklendi.
                    toplamTeslimat++; //toplam teslimat sayısını bulan sayaca ekleme yapıldı.

                }
                //Verilerle oluşturulan mahalle nesnesi gereken veri yapılarına eklendi. ArrayList, yığıt, kuyruk, öncelikli kuyruk.
                motoKurye.Add(mahalle);
                stack.push(mahalle);
                queue.insert(mahalle);
                priorityQueue.insert(mahalle);
                
            }
            //Bileşik veri yapısındaki veriler foreach döngüsüyle yazdırıldı. classın toString metodundan dönen değer.
            Console.WriteLine("Bileşik veri yapısındaki veriler:");
            foreach (Mahalle item in motoKurye)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Dinamik dizinin veri sayısı: {0} ", motoKurye.Count); //toplam mahalle sayısı yazdırıldı.
            Console.WriteLine("Toplam teslimat sayısı: {0} ",toplamTeslimat); //Yapılacak toplam teslimat sayısı yazdırıldı.
            Console.WriteLine();
            Console.WriteLine("Yığıttan veriler siliniyor...");
            while (!stack.isEmpty()) //Yığıttan elemanlar çıkarıldı. Sondan
                Console.WriteLine(stack.pop());
            
            Console.WriteLine();
            Console.WriteLine("Kuyruktan veriler siliniyor...");
            while(!queue.isEmpty()) //Kuyruktan elemanlar çıkarıldı. Baştan
                Console.WriteLine(queue.remove());
            Console.WriteLine();
            Console.WriteLine("Öncelikli kuyruktan veriler azalan sırada siliniyor...");
            while (!priorityQueue.isEmpty()) //Öncelik kuyruktan veriler azalan sırada çıkarıldı. 
                Console.WriteLine(priorityQueue.remove());
            //ürünAdetleri listesindeki her bir müşterinin ürün adetleri int tipinde veri alan kuyruk ve öncelikli kuyru veri yapılarına eklendi.
            foreach (int item in ürünAdetleri)
            {
                intQueue.insert(item);
                intPriorityQueue.insert(item);
            }
            Console.WriteLine("Kuyruktan veriler siliniyor(int tip)...");
            while (!intQueue.isEmpty()) //int tipinde veriler alan kuyruktan veriler siliniyor.
            {
                
                int sayı = intQueue.remove();
                Console.WriteLine("Ödemesi biten müşterinin ürün adedi {0}", sayı);
                işlemTamamlanmaSüreleri += sayı*3; //Ödemesi biten müşterinin işlem süresi hesaplandı.
                Console.WriteLine("İşlem tamamlanma süresi {0}",işlemTamamlanmaSüreleri);
                toplamİşlemTamamlanmaSüreleri += işlemTamamlanmaSüreleri; //Müşterilerin toplam işlem süresi hesaplandı.
                Console.WriteLine();
            }
            //Kasa için ortalama işlem tamamlanma süresi hesaplanıp yazdırıldı.
            Console.WriteLine("Müşterilerin ortalama işlem tamamlanma süresi {0}", (double)toplamİşlemTamamlanmaSüreleri / ürünAdetleri.Length); 
            Console.WriteLine();
            işlemTamamlanmaSüreleri = 0; //değişkenler bir sonraki hesaplama için sıfırlandı.
            toplamİşlemTamamlanmaSüreleri = 0;
            Console.WriteLine("Öncelikli kuyruktan(int tip) veriler artan sırada siliniyor...");
            while(!intPriorityQueue.isEmpty()) //int tipinde veriler alan öncelikli kuyruktan veriler siliniyor.artan sırada.
            {
                int sayı = intPriorityQueue.remove(); //Listeden çıkarıldı ve değişkene atandı.
                Console.WriteLine("Ödemesi biten müşterinin ürün adedi {0} ", sayı);
                işlemTamamlanmaSüreleri += sayı*3; //Ödemesi biten müşterinin işlem süresi hesaplandı.
                Console.WriteLine("İşlem tamamlanma süresi {0} ", işlemTamamlanmaSüreleri);
                toplamİşlemTamamlanmaSüreleri += işlemTamamlanmaSüreleri; //Müşterilerin toplam işlem süresi hesaplandı.
                Console.WriteLine();
            }
            Console.WriteLine("Müşterilerin ortalama işlem tamamlanma süresi {0}", (double)toplamİşlemTamamlanmaSüreleri / ürünAdetleri.Length);  //Kasa için ortalama işlem tamamlanma süresi hesaplanıp yazdırıldı.

        }
    }
}
