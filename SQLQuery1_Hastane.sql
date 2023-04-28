--Doktor i�in Listeleme Prosed�r�
 create procedure DListele
 as begin 
 select*from Doktor
 end
 --Doktor i�in Yeni Veri Ekleme  Prosed�r�
 alter procedure DEkle
 @DTCNo int,
 @DAdSoyad varchar(50),
 @UzmanlikAlani varchar(50),
 @Telefon int,
 @PoliklinikNo varchar(50)
 as begin
 insert into Doktor(DTCNo,DAdSoyad,UzmanlikAlani,Telefon,PoliklinikNo) values (@DTCNo,@DAdSoyad,@UzmanlikAlani,@Telefon,@PoliklinikNo)
 end
 --Doktor i�in G�ncelleme
 alter proc DYenile
 @DoktorNo int,
 @DTCNo int,
 @DAdSoyad varchar(50),
 @UzmanlikAlani varchar(50),
 @Telefon int,
 @PoliklinikNo varchar(50)
 as begin
 update Doktor set DTCNo=@DTCNo,DAdSoyad=@DAdSoyad,
 UzmanlikAlani=@UzmanlikAlani ,
 Telefon=@Telefon ,
 PoliklinikNo=@PoliklinikNo where DoktorNo=@DoktorNo
 end
 --Doktor Silme--
 create proc DSil
 @DoktorNo int
 as begin
 delete from Doktor where DoktorNo=@DoktorNo
 end

 --DOKTOR ARA
alter PROC DAra
@DAdSoyad varchar(50)
as begin
select*from Doktor where DadSoyad=@DAdSoyad 
end


alter PROC DAra1
@DoktorNo int
as begin
select*from Doktor where  DoktorNo=@DoktorNo
end
 -----------
 ------------
 -------------
 --hasta i�in Listeleme Prosed�r�
 create procedure HListele
 as begin 
 select*from Hasta
 end
 --Hasta i�in Yeni Veri Ekleme  Prosed�r�
 CREATE procedure HEkle
 @HAdSoyad varchar(50),
 @HastaTCNo int,
 @HDogumTarihi datetime,
 @Boy int,
 @ReceteNo int,
 @DoktorNo int
 as begin
 insert into Hasta(HAdSoyad,HastaTCNo,HDogumTarihi,Boy,ReceteNo,DoktorNo) values (@HAdSoyad,@HastaTCNo,@HDogumTarihi,@Boy,@ReceteNo,@DoktorNo)
 end
 --Hasta i�in G�ncelleme
 ALTER proc HYenile
 @HastaNo int,
 @HAdSoyad varchar(50),
 @HastaTCNo int,
 @HDogumTarihi datetime,
 @Boy int,
 @ReceteNo int,
 @DoktorNo int
 as begin
 update Hasta set HAdSoyad=@HAdSoyad,
 HastaTCNo=@HastaTCNo ,
 HDogumTarihi=@HDogumTarihi ,
 Boy=@Boy,ReceteNo=@ReceteNo, DoktorNo=@DoktorNo where HastaNo=@HastaNo
 end
 --Hasta Silme--
 create proc HSil
 @HastaNo int
 as begin
 delete from Hasta where HastaNo=@HastaNo
 end

 --hasta ara
create PROC HAra
@HastaTCNo int
as begin
select*from Hasta where HastaTCNo=@HastaTCNo 
end

create PROC HAra1
@HAdSoyad varchar(50)
as begin
select*from Hasta where HAdSoyad=@HAdSoyad 
end
 -----------
 ------------
 -------------

  --poliklinik i�in Listeleme Prosed�r�
 create procedure PListele
 as begin 
 select*from Poliklinik
 end
 --Poliklinik i�in Yeni Veri Ekleme  Prosed�r�
 create procedure PEkle
 @PoliklinikAdi varchar(50),
 @UzmanSayisi int,
 @HemsireSayisi int,
 @YatakSayisi int,
 @HastaNo int,
 @DoktorNo int
 as begin
 insert into Poliklinik(PoliklinikAdi,UzmanSayisi,HemsireSayisi,YatakSayisi,HastaNo,DoktorNo) values (@PoliklinikAdi,@UzmanSayisi,@HemsireSayisi,@YatakSayisi,@HastaNo,@DoktorNo)
 end
 --Poliklinik i�in G�ncelleme
 create proc PYenile
 @PoliklinikNo int,
 @PoliklinikAdi varchar(50),
 @UzmanSayisi int,
 @HemsireSayisi int,
 @YatakSayisi int,
 @HastaNo int,
 @DoktorNo int
 as begin
 update Poliklinik set PoliklinikAdi=@PoliklinikAdi,
 UzmanSayisi=@UzmanSayisi ,
 HemsireSayisi=@HemsireSayisi ,
 YatakSayisi=@YatakSayisi,@HastaNo=@HastaNo, DoktorNo=@DoktorNo where PoliklinikNo=@PoliklinikNo
 end
 --poliklinik Silme--
 create proc PSil
 @PoliklinikNo int
 as begin
 delete from PolikliniK where PoliklinikNo=@PoliklinikNo
 end
 --POL�KL�N�K ARA--
 alter PROC PAra
@PoliklinikNo int
as begin
select*from Poliklinik where PoliklinikNo=@PoliklinikNo 
end

 -----------
 ------------
 -------------
 --Kullan�c� i�in Listeleme Prosed�r�
 create procedure KListele
 as begin 
 select*from Kullanici
 end
 --kullan�c� i�in Yeni Veri Ekleme  Prosed�r�
 alter procedure KEkle
 @KullaniciAdi varchar(50),
 @Sifre varchar(50),
 @TelefonNo char(20)
 as begin
 insert into Kullanici(KullaniciAdi,Sifre,TelefonNo) values (@KullaniciAdi,@Sifre,@TelefonNo)
 end

 create procedure [dbo].[Giris](
 @kad varchar(50),
 @sifre varchar(50)
 )
 as begin 
 select*from Kullanici where KullaniciAdi=@Kad and Sifre=@Sifre
 end

 ---RAPORLAR---
 --1)Polikliniklerin yatak kapasitesi (k�meleme fonk)
 select PoliklinikAdi, avg(YatakSayisi)as'Polokliniklerdeki yatak say�s� ' from Poliklinik group by PoliklinikAdi 
 select*from Poliklinik
 --
 alter proc R1
 as begin
 select PoliklinikAdi, avg(YatakSayisi)as'Polokliniklerdeki yatak say�s� ' from Poliklinik group by PoliklinikAdi order by 'Polokliniklerdeki yatak say�s� ' desc
end


 --2)pOL�KL�N�K HEM��RE SAYISI


alter proc R2
as begin
select PoliklinikAdi,HemsireSayisi from Poliklinik order by HemsireSayisi desc
end

--3)uzmanl�k alanlar�na g�re doktor say�s�
ALTER proc R3
as begin
select UzmanlikAlani,count (UzmanlikAlani)as 'Uzman Doktor Say�s�' from Doktor group by UzmanlikAlani
end

--select * from Doktor d inner join Poliklinik p --2 tablo birle�ecek d/p diye takma ad veriyoruz
--on d.PoliklinikNo=p.PoliklinikNo --birle�ece�i kolonu belirtiyoruz

