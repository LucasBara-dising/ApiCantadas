DROP DATABASE if EXISTS dbCant;
CREATE DATABASE if NOT exists dbCant;
USE dbCant;
CREATE TABLE if not exists tbCantada(id_cant smallint  primary key AUTO_INCREMENT, 
					txtCantada varchar(100) NOT NULL,
                    catCantada varchar(100) NOT NULL);
					
INSERT INTO tbCantada (txtCantada,catCantada) VALUES ("Oi gata Que olhos Lindods","Amor");
INSERT INTO tbCantada (txtCantada,catCantada) VALUES ("Conquistou meu coração", "Crush");
INSERT INTO tbCantada (txtCantada,catCantada) VALUES ("Amo teu abraço", "Fofo");
				
delete from tbCantada where   id_cant=5 ;   

          
SELECT * FROM tbCantada;