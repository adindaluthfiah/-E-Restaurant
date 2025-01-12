PGDMP     8                
    z            e-Rest    15.0    15.0     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16489    e-Rest    DATABASE     �   CREATE DATABASE "e-Rest" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United States.1252';
    DROP DATABASE "e-Rest";
                postgres    false            �            1255    16490    st_delete(character varying)    FUNCTION     
  CREATE FUNCTION public.st_delete(_no_pesanan character varying) RETURNS integer
    LANGUAGE plpgsql
    AS $$
BEGIN
    delete from public.Menu
    where No_Pesanan=_No_Pesanan;
    if found then
        return 1;
    else
        return 0;
    end if;
end    
$$;
 ?   DROP FUNCTION public.st_delete(_no_pesanan character varying);
       public          postgres    false            �            1255    16509 �   st_insert(character varying, character varying, character varying, character varying, character varying, character varying, character varying)    FUNCTION     �  CREATE FUNCTION public.st_insert(_no_pesanan character varying, _nama character varying, _scramble_toast character varying, _bacon_doublect character varying, _avo_toast character varying, _shrimp_toast character varying, _total character varying) RETURNS integer
    LANGUAGE plpgsql
    AS $$
BEGIN
    insert into public.menu
    (
		No_Pesanan,
        Nama,
        Scramble_Toast,
        Bacon_DoubleCT,
		Avo_Toast,
		Shrimp_Toast,
		Total
    )
    values
    (
		_No_Pesanan,
        _Nama,
        _Scramble_Toast,
        _Bacon_DoubleCT,
		_Avo_Toast,
		_Shrimp_Toast,
		_Total
    );
    if found then
        return 1;
    else
        return 0;
    end if;
end
$$;
 �   DROP FUNCTION public.st_insert(_no_pesanan character varying, _nama character varying, _scramble_toast character varying, _bacon_doublect character varying, _avo_toast character varying, _shrimp_toast character varying, _total character varying);
       public          postgres    false            �            1255    16492    st_select()    FUNCTION     �  CREATE FUNCTION public.st_select() RETURNS TABLE(_no_pesanan character varying, _nama character varying, _scramble_toast character varying, _bacon_doublect character varying, _avo_toast character varying, _shrimp_toast character varying, _total character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    return query
    select No_Pesanan,Nama,Scramble_Toast,Bacon_DoubleCT,Avo_Toast,Shrimp_Toast,Total from Menu;
END
$$;
 "   DROP FUNCTION public.st_select();
       public          postgres    false            �            1255    16493 �   st_update(character varying, character varying, character varying, character varying, character varying, character varying, character varying)    FUNCTION     d  CREATE FUNCTION public.st_update(_no_pesanan character varying, _nama character varying, _scramble_toast character varying, _bacon_doublect character varying, _avo_toast character varying, _shrimp_toast character varying, _total character varying) RETURNS integer
    LANGUAGE plpgsql
    AS $$
BEGIN
    update Menu SET
        Nama=_Nama,
        Scramble_Toast=_Scramble_Toast,
        Bacon_DoubleCT=_Bacon_DoubleCT,
		Avo_Toast =_Avo_Toast,
		Shrimp_Toast=_Shrimp_Toast,
		Total=_Total
    where No_Pesanan=_No_Pesanan;
    if found then
        return 1;
    else
        return 0;
    end if;
end    
$$;
 �   DROP FUNCTION public.st_update(_no_pesanan character varying, _nama character varying, _scramble_toast character varying, _bacon_doublect character varying, _avo_toast character varying, _shrimp_toast character varying, _total character varying);
       public          postgres    false            �            1259    16510    menu    TABLE     0  CREATE TABLE public.menu (
    no_pesanan character varying(100) NOT NULL,
    nama character varying(100),
    scramble_toast character varying(50),
    bacon_doublect character varying(50),
    avo_toast character varying(50),
    shrimp_toast character varying(50),
    total character varying(50)
);
    DROP TABLE public.menu;
       public         heap    postgres    false            �          0    16510    menu 
   TABLE DATA           p   COPY public.menu (no_pesanan, nama, scramble_toast, bacon_doublect, avo_toast, shrimp_toast, total) FROM stdin;
    public          postgres    false    214   j       i           2606    16514    menu menu_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.menu
    ADD CONSTRAINT menu_pkey PRIMARY KEY (no_pesanan);
 8   ALTER TABLE ONLY public.menu DROP CONSTRAINT menu_pkey;
       public            postgres    false    214            �      x������ � �     