

/* Nom(s) : Fabrice Kouakou & Jeff-Love Jean Francois */


/* PARTIE 2 */
/* detruit la bd si elle existe */

use master
go
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'Bd_Reseau')
BEGIN
    ALTER DATABASE Bd_Reseau SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	drop database Bd_Reseau
END



/* cr�ation de votre bd  */

CREATE DATABASE Bd_Reseau
go

Use Bd_Reseau
go

/* voici le code permettant de donner les droits � un autre usager, ici nomm� [sonNoDa] */
/* cr�ation de l'usager */

--CREATE USER [Kouakou Filiwa Fabrice Leonce] FOR LOGIN [corporatif\2342864] WITH DEFAULT_SCHEMA=[dbo]
--GO
--/* sp�cification de ses droits*/
--ALTER ROLE [db_owner] ADD MEMBER [Kouakou Filiwa Fabrice Leonce]

CREATE USER [Jeff] FOR LOGIN [corporatif\2334062] WITH DEFAULT_SCHEMA=[dbo]
GO
/* sp�cification de ses droits*/
ALTER ROLE [db_owner] ADD MEMBER [Jeff]

GO

/* cr�ation de vos tables simples */

create table tbl_compagnie(
id_compagnie int identity primary key,
nom nvarchar(200) unique
)
go

create table tbl_piece(
id_piece int identity primary key,
description nvarchar(200),
numeroIndustrie nvarchar(200) unique
)
go

create table tbl_employee(
id_employee int identity primary key,
nom nvarchar(200),
prenom nvarchar(200),
email nvarchar(200) null 
)
go


/* 9- modification d'un null en not null */

alter table tbl_employee
alter column email nvarchar(200) not null
go

alter table tbl_employee 
add constraint UQ_email unique (email)
go

alter table tbl_employee
add constraint Ck_email Check (email like '%[@]%')
go



/*	4- Cas �u toutes les contraintes sont d�finis DANS le create de la table, 
	auncune contrainte apr�s le create (dans le cas d'une table avec une cl� �trang�re) */

	create table tbl_projet(
	id_projet int identity primary key,
	nom nvarchar(200) unique,
	description nvarchar(200) unique, 
	id_compagnie int references tbl_compagnie(id_compagnie) not null
	)
	go

	create table tbl_stock(
	id_stock int identity primary key, 
	quantite_stock int,
	quantite_prevu int,
	check (quantite_stock >= 0),
	Check (quantite_prevu > 0),
	id_piece int references tbl_piece(id_piece) not null,
	id_projet int references tbl_projet(id_projet) not null,
	constraint UQ_projetPiece unique (id_piece, id_projet)
	)
	go


/*  5- Cas o� toutes les contraintes sont d�finis APR�S la creation de la table (dans le cas d'une table avec cl� �trang�re)*/
	
		/* contraintes APRES la c�ation de la derni�re table */

		create table tbl_impute(
		id_impute int identity primary key, 
		id_employee int not null,
		id_stock int not null,
		quantite_impute int,
		date_imputee date
		)
		go

		alter table tbl_impute
		add constraint FK_impute_employee foreign key (id_employee) references tbl_employee(id_employee),
		constraint FK_impute_stock foreign key (id_stock) references tbl_stock(id_stock),
		constraint CK_quantiteImpute Check (quantite_impute > 0),
		constraint Dt_dateImpute check (date_imputee <= getDate())

		go


 --pour ajouter les piece il faut prendre ceux qui n'ont pas de generique 
  
/* 10-m'assure qu'il n'y a pas 2 pi�ces pareils pour un projet */ --voir question 4
/* 11- unicit� */ --voir question 4


/* PARTIE 3 */
/* 2. a) insertion de donn�es en batch � partir de bdDonnee pour les employes */

insert into tbl_employee(prenom, nom, email) select Prénom, Nom, [Adresse Email] from BDDonneesTP.DBO.employe$
go

/* 2. b) insertion de donn�es en batch � partir de bdDonnee pour les pieces de votre sujet */

insert into tbl_piece(description, numeroIndustrie) select Description, [Numéro de Pièce] from BDDonneesTP.DBO.reseau$
go

/* 2. c) pratique cross apply : trouver les employ�s qui ont un nom et pr�nom identique � d�autres. */




select distinct e.nom, e.prenom, e.email
from tbl_employee e cross apply (select* from tbl_employee 
where tbl_employee.nom = e.nom 
and tbl_employee.prenom = e.prenom  
and tbl_employee.id_employee <> e.id_employee) employeeIdentique 
ORDER BY e.nom, e.prenom;
go

/* 3. ajout de donn�es, au moins 3 dans chaque table */

/* 3. a)	Pour la table de projet, ajouter 4 donn�es dont 2 pour la m�me compagnie */

INSERT INTO tbl_compagnie (nom) VALUES
('HyperNet Solutions'),
('Infinity Network Systems'),
('FiberLink Technologies'),
('SkyBridge Communications'),
('CoreConnect Networks');
go


insert into tbl_projet(nom, description, id_compagnie)
select 
    'Projet Alpha', 'Description du projet Alpha', c.id_compagnie
from tbl_compagnie c
where c.nom = 'HyperNet Solutions'

union all

select 
    'Projet Beta', 'Description du projet Beta', c.id_compagnie
from tbl_compagnie c
where c.nom = 'Infinity Network Systems'

union all

select 
    'Projet Gamma', 'Description du projet Gamma', c.id_compagnie
from tbl_compagnie c
where c.nom = 'HyperNet Solutions'

union all

select 
    'Projet Delta', 'Description du projet Delta', c.id_compagnie
from tbl_compagnie c
where c.nom = 'FiberLink Technologies';

go

/* 3. b)	Pour la table des projets-pi�ces, faites des ajouts pour 2 projets diff�rents et pour chacun utiliser au moins 3 pi�ces diff�rentes. 
			Une m�me pi�ce sera dans les 2 projets*/
			
INSERT INTO tbl_stock (id_projet, id_piece, quantite_prevu, quantite_stock)
SELECT p.id_projet, pi.id_piece, 55, 100
FROM tbl_projet p
JOIN tbl_piece pi ON pi.description IN ('Netgear Nighthawk RAX120', 'Cable Matters Cat 6a', 'Axis Q6115-E PTZ Camera')
WHERE p.nom = 'Projet Alpha';
go

INSERT INTO tbl_stock (id_projet, id_piece, quantite_prevu, quantite_stock)
SELECT p.id_projet, pi.id_piece, 70, 250
FROM tbl_projet p
JOIN tbl_piece pi ON pi.description IN ('Cable Matters Cat 6a', 'Asus XG-C100C', 'Belkin Patch Cable Cat6a 1m')
WHERE p.nom = 'Projet Beta';
go


/* 3. c)	Pour la table d�imputation, utiliser comme employ�, un employ� ayant le m�me nom qu�un autre. 			
			Pour un m�me projet,un des employ�s aura 2 imputations et l�autre une. 
			Ajouter 3 imputations pour le m�me projet.
			Ajouter 2 pi�ces diff�rentes parmi celles import�es et une pareille. Bien entendu, ce doit �tre les pi�ces d�j� associ�es � ce projet (projets-pi�ces). 
			Assurez-vous que ce soit toujours la date d�aujourd�hui lorsque vous ex�cutez votre script.
			*/



INSERT INTO [dbo].[tbl_impute] 
    ([id_employee], [id_stock], [quantite_impute], [date_imputee])



select (select distinct id_employee from tbl_employee e1 where  e1.nom = 'Tremblay' 
AND e1.prenom = 'émilie' 
AND e1.email = 'emilie.trem@gmail.com'), tbl_stock.id_stock,  5, GETDATE()
from tbl_stock 
inner join tbl_projet on tbl_stock.id_projet = tbl_projet.id_projet 
inner join tbl_piece on tbl_piece.id_piece = tbl_stock.id_piece
where tbl_stock.id_piece in (SELECT id_piece FROM tbl_piece WHERE description = 'Netgear Nighthawk RAX120')
and tbl_stock.id_projet in (select tbl_projet.id_projet from tbl_projet where nom = 'Projet Alpha')

UNION ALL

SELECT (select distinct id_employee from tbl_employee e1 where  e1.nom = 'Tremblay' 
AND e1.prenom = 'émilie' 
AND e1.email = 'emilie.trem@gmail.com'), tbl_stock.id_stock,  5, GETDATE()
FROM tbl_stock 
inner join tbl_projet on tbl_stock.id_projet = tbl_projet.id_projet 
inner join tbl_piece on tbl_piece.id_piece = tbl_stock.id_piece
where tbl_stock.id_piece = (SELECT id_piece FROM tbl_piece WHERE description = 'Cable Matters Cat 6a') 
and tbl_stock.id_projet = (select tbl_projet.id_projet from tbl_projet where nom = 'Projet Alpha')

UNION ALL

SELECT TOP 1 e2.id_employee, tbl_stock.id_stock, 5, GETDATE()
FROM tbl_employee e1
INNER JOIN tbl_employee e2 ON e1.nom = e2.nom 
                           AND e1.prenom = e2.prenom 
                           AND e1.id_employee <> e2.id_employee 
                           AND e2.email <> 'emilie.trem@gmail.com'  -- S'assurer que c'est un autre email
INNER JOIN tbl_stock ON tbl_stock.id_projet = (SELECT id_projet FROM tbl_projet WHERE nom = 'Projet Alpha')
INNER JOIN tbl_piece ON tbl_piece.id_piece = tbl_stock.id_piece
WHERE tbl_stock.id_piece IN (SELECT id_piece FROM tbl_piece WHERE description = 'Netgear Nighthawk RAX120')
AND e1.nom = 'Tremblay' 
AND e1.prenom = 'emilie'

go





/* c) m�me chose pour un 2e projet */ 

INSERT INTO [dbo].[tbl_impute] 
    ([id_employee], [id_stock], [quantite_impute], [date_imputee])



select (select distinct id_employee from tbl_employee e1 where  e1.nom = 'Bergeron' 
AND e1.prenom = 'Michel' 
AND e1.email = 'mbergeron@gmail.com'), tbl_stock.id_stock,  5, GETDATE()
from tbl_stock 
inner join tbl_projet on tbl_stock.id_projet = tbl_projet.id_projet 
inner join tbl_piece on tbl_piece.id_piece = tbl_stock.id_piece
where tbl_stock.id_piece in (SELECT id_piece FROM tbl_piece WHERE description = 'Belkin Patch Cable Cat6a 1m')
and tbl_stock.id_projet in (select tbl_projet.id_projet from tbl_projet where nom = 'Projet Beta')

UNION ALL

SELECT (select distinct id_employee from tbl_employee e1 where  e1.nom = 'Bergeron' 
AND e1.prenom = 'Michel' 
AND e1.email = 'mbergeron@gmail.com'), tbl_stock.id_stock,  5, GETDATE()
FROM tbl_stock 
inner join tbl_projet on tbl_stock.id_projet = tbl_projet.id_projet 
inner join tbl_piece on tbl_piece.id_piece = tbl_stock.id_piece
where tbl_stock.id_piece = (SELECT id_piece FROM tbl_piece WHERE description = 'Asus XG-C100C') 
and tbl_stock.id_projet = (select tbl_projet.id_projet from tbl_projet where nom = 'Projet Beta')

UNION ALL

SELECT TOP 1 e2.id_employee, tbl_stock.id_stock, 5, GETDATE()
FROM tbl_employee e1
INNER JOIN tbl_employee e2 ON e1.nom = e2.nom 
                           AND e1.prenom = e2.prenom 
                           AND e1.id_employee <> e2.id_employee 
                           AND e2.email <> 'mbergeron@gmail.com'  -- S'assurer que c'est un autre email
INNER JOIN tbl_stock ON tbl_stock.id_projet = (SELECT id_projet FROM tbl_projet WHERE nom = 'Projet Beta')
INNER JOIN tbl_piece ON tbl_piece.id_piece = tbl_stock.id_piece
WHERE tbl_stock.id_piece IN (SELECT id_piece FROM tbl_piece WHERE description = 'Belkin Patch Cable Cat6a 1m')
AND e1.nom = 'Bergeron' 
AND e1.prenom = 'Michel'

go

/* 4. un select des tables pour prouver les bons ajouts */

SELECT        tbl_compagnie.nom, tbl_employee.nom AS Expr1, tbl_employee.prenom, tbl_employee.email, tbl_impute.quantite_impute, tbl_impute.date_imputee, tbl_piece.description, 
                         tbl_piece.numeroIndustrie, tbl_impute.id_employee, tbl_impute.id_stock, tbl_projet.nom AS Expr2, tbl_projet.description AS Expr3, tbl_projet.id_compagnie, tbl_stock.quantite_stock, 
                         tbl_stock.quantite_prevu, tbl_stock.id_piece, tbl_stock.id_projet
FROM            tbl_projet INNER JOIN
                         tbl_compagnie ON tbl_projet.id_compagnie = tbl_compagnie.id_compagnie INNER JOIN
                         tbl_stock ON tbl_projet.id_projet = tbl_stock.id_projet INNER JOIN
                         tbl_piece ON tbl_stock.id_piece = tbl_piece.id_piece INNER JOIN
                         tbl_impute INNER JOIN
                         tbl_employee ON tbl_impute.id_employee = tbl_employee.id_employee ON tbl_stock.id_stock = tbl_impute.id_stock

go

/* 5.	Faites une instruction SQL qui vous affiche, pour chaque pi�ce, le nombre d�imputations r�alis� en tout dans le magasin, 
		la quantit� totale de pi�ces imput�es, 
		et le nombre de projets dont elle fait partie. (Select avanc�).
*/

SELECT 
    p.id_piece, 
    p.description, 
    statistiques.nombre_imputations, 
    statistiques.quantite_totale_imputee, 
    statistiques.nombre_projets
FROM tbl_piece p
INNER JOIN (
    SELECT 
        s.id_piece,
        COUNT(i.id_stock) AS nombre_imputations,
        SUM(i.quantite_impute) AS quantite_totale_imputee,
        COUNT(DISTINCT s.id_projet) AS nombre_projets
    FROM tbl_stock s
    INNER JOIN tbl_impute i ON s.id_stock = i.id_stock
    GROUP BY s.id_piece
) statistiques ON p.id_piece = statistiques.id_piece;

go
/* 6. tests de contrainte  */
/* contrainte CHECK sur email */	

	--alter table tbl_employee
	--add constraint Ck_email Check (email like '%[@]%')

	--INSERT INTO tbl_employee(email) VALUES ('jeffLoveGmail.com')

/* contrainte CHECK sur quantitePrevu */	

	--Check (quantite_prevu >= 0 a voir un peu plus haut dans la table stock

	--INSERT INTO tbl_stock (id_piece, id_projet,  quantite_prevu) VALUES (4, 1, -5)

/* contrainte CHECK sur quantiteStock */

	--Check (quantite_stock >= 0) voir plus haut dans la table stock

	--INSERT INTO tbl_stock (id_piece, id_projet,  quantite_stock) VALUES (4, 1, -2)
	
/* contrainte CHECK sur quantitePieceImpute */

	--constraint CK_quantiteImpute Check (quantite_impute > 0)

	--INSERT INTO tbl_impute (id_employee, id_stock, quantite_impute) VALUES (1, 1, 0);


/* contrainte sur dateImputation */

	--constraint Dt_dateImpute check (date_imputee <= getDate())

	--INSERT INTO tbl_impute (id_employee, id_stock, date_imputee) VALUES (1, 1, '2030-01-01')
	
/* m'assure qu'il n'y a pas 2 pi�ces pareils pour un projet */

	--constraint UQ_projetPiece unique (id_piece, id_projet)

	--INSERT INTO tbl_stock (id_piece, id_projet) VALUES (1, 1)
	
/* La description d�un projet ne pourra pas �tre identique � un autre projet*/

	--description nvarchar(200) unique voir creation de la table projet plus haut 

	--INSERT INTO tbl_projet (nom, description, id_compagnie) VALUES ('Projet X', 'Description du projet Alpha', 3)

/* le nom de compagnie ne peut pas �tre identique � une autre compagnie */

	--nom nvarchar(200) unique
	--INSERT INTO tbl_compagnie(nom) VALUES ('HyperNet Solutions')

/* les num�ros d�une pi�ce de l�industrie doivent �tre tous diff�rents*/

	--numeroIndustrie nvarchar(200) unique
	--INSERT INTO tbl_piece (numeroIndustrie) VALUES ('RAX120-100NAS')




CREATE OR ALTER PROCEDURE RechercherPieceParNumeroIndustrie
    @noIndustrie NVARCHAR(100)
AS
BEGIN
    SELECT id_piece ,numeroIndustrie, description
    FROM tbl_piece
    WHERE numeroIndustrie LIKE '%' + @noIndustrie + '%'
    ORDER BY numeroIndustrie;
END
GO


CREATE OR ALTER PROCEDURE RechercherProjetsParNumeroIndustrie
    @numeroIndustrie NVARCHAR(200)
AS
BEGIN
    SELECT 
        p.id_projet,
        p.nom AS nom_projet,
        p.description AS description_projet
    FROM tbl_piece pi
    INNER JOIN tbl_stock s ON pi.id_piece = s.id_piece
    INNER JOIN tbl_projet p ON s.id_projet = p.id_projet
    WHERE pi.numeroIndustrie LIKE '%' + @numeroIndustrie + '%'
    ORDER BY p.nom;
END
GO



CREATE OR ALTER PROCEDURE MettreAJourStock
    @id_piece INT,
    @id_projet INT,
    @quantite_impute INT
AS
BEGIN

    UPDATE tbl_stock
    SET quantite_stock = quantite_stock - @quantite_impute
    WHERE id_piece = @id_piece AND id_projet = @id_projet;
END
go






CREATE or alter VIEW VueListerQuantitePrevueProjet
AS
SELECT 
    s.id_stock,
    p.id_projet,
    p.nom AS nom_projet,
    pi.id_piece,
    pi.description AS nom_piece,
    s.quantite_prevu
FROM 
    tbl_stock s
INNER JOIN 
    tbl_projet p ON s.id_projet = p.id_projet
INNER JOIN 
    tbl_piece pi ON s.id_piece = pi.id_piece
GO


CREATE or alter PROCEDURE ModifierQuantitePrevueProjet
    @id_stock INT,
    @id_projet INT,
    @nom_projet NVARCHAR(200),
    @id_piece INT,
    @nom_piece NVARCHAR(200),
    @quantite_prevu INT
AS
BEGIN
    UPDATE VueListerQuantitePrevueProjet
    SET quantite_prevu = @quantite_prevu
    WHERE id_stock = @id_stock
END
GO

create table tbl_inventaireNonAssigne(
no_inventaireNonAssigne int identity primary key, 
no_piece int unique , 
quantite int,
)
go

CREATE OR ALTER PROCEDURE SupprimerProjetEtRestaurerInventaire
    @idProjet int
AS
BEGIN TRY
    SET NOCOUNT ON;
    
	BEGIN TRANSACTION;

    BEGIN

            UPDATE tbl_inventaireNonAssigne
            SET quantite = quantite + tbl_stock.quantite_stock
			from tbl_inventaireNonAssigne INNER JOIN tbl_stock 
			on tbl_inventaireNonAssigne.no_piece = tbl_stock.id_piece
			where tbl_stock.id_projet = @idProjet

            INSERT INTO tbl_inventaireNonAssigne (no_piece, quantite)
            select tbl_stock.id_piece, tbl_stock.quantite_stock
			from tbl_inventaireNonAssigne right outer join tbl_stock 
			on tbl_inventaireNonAssigne.no_piece = tbl_stock.id_piece
			where tbl_stock.id_projet = @idProjet and tbl_inventaireNonAssigne.no_piece is null

    END

	    DELETE FROM tbl_stock WHERE tbl_stock.id_projet = @idProjet;
		
		DELETE FROM tbl_Projet WHERE id_projet = @idProjet;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
    BEGIN
        ROLLBACK TRANSACTION;
        THROW 51000, 'Probleme durant l''execution, il existe une imputation sur ce projet, la suppression est annulee.', 1;
    END
END CATCH;
go

--exec SupprimerProjetEtRestaurerInventaire 2

--select * from tbl_stock
--select* from tbl_impute
--select* from tbl_projet
--select* from tbl_inventaireNonAssigne


/*
/* Script de vérification du bon fonctionnement de la procédure de suppression de projet */

-- 1. Création d’un projet temporaire
DECLARE @id_projet INT;
DECLARE @id_piece1 INT;
DECLARE @id_piece2 INT;

-- Création du projet
INSERT INTO tbl_projet (nom, description, id_compagnie)
VALUES ('Projet Temporaire', 'Projet test pour destruction', 
       (SELECT TOP 1 id_compagnie FROM tbl_compagnie))
SET @id_projet = SCOPE_IDENTITY();

-- 2. Ajout de deux pièces au projet
-- On récupère des pièces existantes
SELECT TOP 2 @id_piece1 = id_piece FROM tbl_piece WHERE description IS NOT NULL ORDER BY id_piece;
SELECT TOP 1 @id_piece2 = id_piece FROM tbl_piece WHERE id_piece <> @id_piece1;

-- Insertion dans tbl_stock
INSERT INTO tbl_stock (id_projet, id_piece, quantite_prevu, quantite_stock)
VALUES 
(@id_projet, @id_piece1, 50, 100),
(@id_projet, @id_piece2, 40, 80);

-- 3. Ajout manuel d’une des pièces à tbl_inventaireNonAssigne
INSERT INTO tbl_inventaireNonAssigne (no_piece, quantite)
VALUES (@id_piece1, 5);

-- 4. Sélections AVANT suppression

SELECT * FROM tbl_projet WHERE id_projet = @id_projet;
SELECT * FROM tbl_stock WHERE id_projet = @id_projet;
SELECT * FROM tbl_inventaireNonAssigne WHERE no_piece IN (@id_piece1, @id_piece2);

-- 5. Appel de votre procédure de suppression
EXEC SupprimerProjetEtRestaurerInventaire @id_projet;

-- 6. Sélections APRÈS suppression

SELECT * FROM tbl_projet WHERE id_projet = @id_projet;
SELECT * FROM tbl_stock WHERE id_projet = @id_projet;
SELECT * FROM tbl_inventaireNonAssigne WHERE no_piece IN (@id_piece1, @id_piece2);
*/

/*
/* TEST NON-FONCTIONNEMENT : Suppression d’un projet avec pièces imputées */

DECLARE @id_projet INT;
DECLARE @id_piece1 INT;
DECLARE @id_employe INT;
DECLARE @id_stock INT;

-- Création du projet
INSERT INTO tbl_projet (nom, description, id_compagnie)
VALUES ('Projet Imputation', 'Projet test échec suppression', 
       (SELECT TOP 1 id_compagnie FROM tbl_compagnie));
SET @id_projet = SCOPE_IDENTITY();

-- Récupération d'une pièce existante
SELECT TOP 1 @id_piece1 = id_piece FROM tbl_piece WHERE description IS NOT NULL ORDER BY id_piece;


-- Insertion dans tbl_stock
INSERT INTO tbl_stock (id_projet, id_piece, quantite_prevu, quantite_stock)
VALUES (@id_projet, @id_piece1, 20, 50);
SET @id_stock = SCOPE_IDENTITY();

-- Création d’un employé pour faire une imputation
INSERT INTO tbl_employee (nom, prenom, email) VALUES ('Test', 'Employe', 'testEmploye@gmail.com');
SET @id_employe = SCOPE_IDENTITY();

-- Création d'une imputation (rendra la suppression invalide)
INSERT INTO tbl_impute (
		id_employee,
		id_stock,
		quantite_impute,
		date_imputee )
VALUES (@id_employe, @id_stock, 5, GETDATE());

-- Sélections AVANT suppression
SELECT * FROM tbl_projet WHERE id_projet = @id_projet;
SELECT * FROM tbl_stock WHERE id_projet = @id_projet;
SELECT * FROM tbl_impute WHERE id_stock = @id_stock;


    EXEC SupprimerProjetEtRestaurerInventaire @id_projet;


-- Sélections APRÈS tentative de suppression
SELECT * FROM tbl_projet WHERE id_projet = @id_projet;
SELECT * FROM tbl_stock WHERE id_projet = @id_projet;
SELECT * FROM tbl_impute WHERE id_stock = @id_stock;

*/






/* ============================================
   PARTIE 4 : LES D�CLENCHEURS (TRIGGER)
   Objectif : Ne pas d�passer la quantit� pr�vue
   ============================================ */

/* a) Cr�ation du d�clencheur avec THROW et TRY...CATCH */

--CREATE OR ALTER TRIGGER verifiQtePrevu
--ON tbl_stock
--AFTER INSERT, UPDATE
--AS
--BEGIN
--    SET NOCOUNT ON;

--    BEGIN TRY
--        IF EXISTS (
--            SELECT 1 
--            FROM inserted i
--            LEFT JOIN (
--                SELECT id_stock, SUM(quantite_impute) AS totalImpute
--                FROM tbl_impute
--                GROUP BY id_stock
--            ) impTotal ON i.id_stock = impTotal.id_stock
--            WHERE i.quantite_prevu < i.quantite_stock + ISNULL(impTotal.totalImpute, 0)
--        )
--        BEGIN
--            THROW 50001, 'La quantit� pr�vue est d�pass�e pour ce projet-pi�ce.', 1;
--        END
--    END TRY
--    BEGIN CATCH
--        ROLLBACK TRANSACTION;
--        THROW;
--    END CATCH
--END;
--GO

--/* b) Une pi�ce dans 2 projets + 2 imputations */

---- Imputation 1 - Projet Alpha
--INSERT INTO tbl_impute (id_employee, id_stock, quantite_impute, date_imputee)
--SELECT TOP 1 id_employee, s.id_stock, 4, GETDATE()
--FROM tbl_employee e
--inner join tbl_stock s ON s.id_piece = (SELECT id_piece FROM tbl_piece WHERE description = 'Cable Matters Cat 6a')
--inner join tbl_projet p ON s.id_projet = p.id_projet
--WHERE p.nom = 'Projet Alpha';

---- Imputation 2 - Projet Beta
--INSERT INTO tbl_impute (id_employee, id_stock, quantite_impute, date_imputee)
--SELECT TOP 1 id_employee, s.id_stock, 6, GETDATE()
--FROM tbl_employee e
--inner join tbl_stock s ON s.id_piece = (SELECT id_piece FROM tbl_piece WHERE description = 'Cable Matters Cat 6a')
--inner join tbl_projet p ON s.id_projet = p.id_projet
--WHERE p.nom = 'Projet Beta';
--GO

--/* c) Tests d'ajout */

---- Test 1 (Ajout REFUS�) : QtePrevue 10, Stock 5, Imputations 6 ? 10 < 5+6=11
---- Calcul : 10 >= (5 + 6 = 11) ? Faux ? REFUS�
--INSERT INTO tbl_stock (id_projet, id_piece, quantite_prevu, quantite_stock)
--SELECT p.id_projet, pi.id_piece, 10, 5
--FROM tbl_projet p
--inner join tbl_piece pi ON pi.description = 'Cable Matters Cat 6a'
--WHERE p.nom = 'Projet Beta';


---- Test 2 (Ajout ACCEPT�) : QtePrevue 20, Stock 5, Imputations 6 ? 20 >= 11
---- Calcul : 20 >= (5 + 6 = 11) ? Vrai ? ACCEPT�
--INSERT INTO tbl_stock (id_projet, id_piece, quantite_prevu, quantite_stock)
--SELECT p.id_projet, pi.id_piece, 20, 5
--FROM tbl_projet p
--inner join tbl_piece pi ON pi.description = 'Cable Matters Cat 6a'
--WHERE p.nom = 'Projet Alpha';
----select * from tbl_inventaireNonAssigne




---- Test 3 (Ajout en lot REFUS� pour Gamma)
---- Projet Gamma : 10 < 11 (Stock) ? Faux ? REFUS�
---- Projet Delta : 30 >= 10 ? OK (correct)
--INSERT INTO tbl_stock (id_projet, id_piece, quantite_prevu, quantite_stock)
--SELECT p.id_projet, pi.id_piece,
--       CASE WHEN p.nom = 'Projet Gamma' THEN 10 ELSE 30 END,
--       CASE WHEN p.nom = 'Projet Gamma' THEN 11 ELSE 10 END
--FROM tbl_projet p
--inner join tbl_piece pi ON pi.description = 'Asus XG-C100C'
--WHERE p.nom IN ('Projet Gamma', 'Projet Delta');

---- Test 4 (Ajout en lot ACCEPT�)
---- Gamma: 20 >= 5, Delta: 40 >= 10 ? OK
--INSERT INTO tbl_stock (id_projet, id_piece, quantite_prevu, quantite_stock)
--SELECT p.id_projet, pi.id_piece,
--       CASE WHEN p.nom = 'Projet Gamma' THEN 20 ELSE 40 END,
--       CASE WHEN p.nom = 'Projet Gamma' THEN 5 ELSE 10 END
--FROM tbl_projet p
--inner join tbl_piece pi ON pi.description = 'Belkin Patch Cable Cat6a 1m'
--WHERE p.nom IN ('Projet Gamma', 'Projet Delta');
--GO


--/* d) Tests de modification */

---- Modif 1 (REFUS�E)
---- Projet Alpha, Cable Matters Cat 6a : QtePrevue 20, Imput�e 6, Stock 15
---- Calcul : 20 < (15 + 6 = 21) ? Faux ? REFUS�
--UPDATE tbl_stock
--SET quantite_stock = 15
--WHERE id_projet = (SELECT id_projet FROM tbl_projet WHERE nom = 'Projet Alpha')
--  AND id_piece = (SELECT id_piece FROM tbl_piece WHERE description = 'Cable Matters Cat 6a');
--GO


----  Modif 2 (ACCEPT�E)
---- Projet Alpha, Cable Matters Cat 6a : QtePrevue 20, Imput�e 6, Stock 10
---- Calcul : 20 >= (10 + 6 = 16) ? OK
--UPDATE tbl_stock
--SET quantite_stock = 10
--WHERE id_projet = (SELECT id_projet FROM tbl_projet WHERE nom = 'Projet Alpha')
--  AND id_piece = (SELECT id_piece FROM tbl_piece WHERE description = 'Cable Matters Cat 6a');
--GO

----  Modif en lot (REFUS�E pour Projet Gamma)
---- Gamma: 10 < 15 ? Faux, Delta: 30 >= 5 ? OK
--UPDATE tbl_stock
--SET quantite_stock = 
--    CASE 
--        WHEN id_projet = (SELECT id_projet FROM tbl_projet WHERE nom = 'Projet Gamma') THEN 15
--        WHEN id_projet = (SELECT id_projet FROM tbl_projet WHERE nom = 'Projet Delta') THEN 5
--        ELSE quantite_stock
--    END
--WHERE id_piece = (SELECT id_piece FROM tbl_piece WHERE description = 'Asus XG-C100C')
--  AND id_projet IN (
--      SELECT id_projet FROM tbl_projet WHERE nom IN ('Projet Gamma', 'Projet Delta')
--  );
--GO

---- Modif en lot (ACCEPT�E)
---- Gamma: 20 >= 10, Delta: 40 >= 15 ? OK
--UPDATE tbl_stock
--SET quantite_stock = 
--    CASE 
--        WHEN id_projet = (SELECT id_projet FROM tbl_projet WHERE nom = 'Projet Gamma') THEN 10
--        WHEN id_projet = (SELECT id_projet FROM tbl_projet WHERE nom = 'Projet Delta') THEN 15
--        ELSE quantite_stock
--    END
--WHERE id_piece = (SELECT id_piece FROM tbl_piece WHERE description = 'Belkin Patch Cable Cat6a 1m')
--  AND id_projet IN (
--      SELECT id_projet FROM tbl_projet WHERE nom IN ('Projet Gamma', 'Projet Delta')
--  );
--GO

