use crud;

INSERT INTO 
	`clients`(`first_name`, `last_name`, `type_person`, `cpf_cnpj`)
VALUES
	('Krasgi_1','Krasgi_1','fisica', '91666676071'),
	('Krasgi_2','Krasgi_2','fisica', '63687433013'),
    ('Krasgi_3','Krasgi_3','fisica', '82814365061'),
    ('Krasgi_4','Krasgi_4','juridica', '05717289000188'),
    ('Krasgi_5','Krasgi_5','juridica', '30340242000195'),
    ('Krasgi_6','Krasgi_6','fisica', '60692582070'),
    ('Krasgi_7','Krasgi_7','juridica', '05196150000136'),
    ('Krasgi_8','Krasgi_8','juridica', '01073080000178'),
    ('Krasgi_9','Krasgi_9','fisica', '51630396010'),
    ('Krasgi_10','Krasgi_10','juridica', '24365041000140'),
    ('Krasgi_11','Krasgi_11','fisica', '29742930007'),
    ('Krasgi_12','Krasgi_12','juridica', '68409143000195');
    
INSERT INTO `phones`(`client_id`, `number`, `type`)
VALUES(1,'(16)91846-6344', 'celular'),
	(2,'(58)97518-2538', 'comercial'),
    (3,'(17)32366102', 'residencial'),
    (4,'(39)96941-2239', 'celular'),
   (5,'(16)91846-6344', 'celular'),
	(6,'(58)97518-2538', 'comercial'),
    (7,'(17)32366102', 'residencial'),
    (8,'(39)96941-2239', 'celular'),
     (9,'(16)91846-6344', 'celular'),
	(10,'(58)97518-2538', 'comercial'),
    (11,'(17)32366102', 'residencial'),
    (12,'(39)96941-2239', 'celular');
    
INSERT INTO `adresses`(`client_id`, `address`, `zip_code`, `number`, `neighborhood`, `city`, `uf`, `type`)
VALUES(1,'Rua Teste 1', '66896-899', '123', 'Bairro Teste 1', 'Sao Jose do Rio Preto', 'SP', 'residencial'),
	(2,'Rua Teste 2', '66896-899', '123', 'Bairro Teste 2', 'Sao Jose do Rio Preto', 'SP', 'comercial'),
    (3,'Rua Teste 3', '66896-899', '123', 'Bairro Teste 3', 'Sao Jose do Rio Preto', 'SP', 'cobranca'),
	(4,'Rua Teste 4', '66896-899', '123', 'Bairro Teste 4', 'Sao Jose do Rio Preto', 'SP', 'entrega'),
    (5,'Rua Teste 5', '66896-899', '123', 'Bairro Teste 5', 'Sao Jose do Rio Preto', 'SP', 'correspondencia'),
	(6,'Rua Teste 6', '66896-899', '123', 'Bairro Teste 6', 'Sao Jose do Rio Preto', 'SP', 'residencial'),
    (7,'Rua Teste 7', '66896-899', '123', 'Bairro Teste 7', 'Sao Jose do Rio Preto', 'SP', 'comercial'),
    (8,'Rua Teste 8', '66896-899', '123', 'Bairro Teste 8', 'Sao Jose do Rio Preto', 'SP', 'cobranca'),
    (9,'Rua Teste 9', '66896-899', '123', 'Bairro Teste 9', 'Sao Jose do Rio Preto', 'SP', 'entrega'),
    (10,'Rua Teste 10', '66896-899', '123', 'Bairro Teste 10', 'Sao Jose do Rio Preto', 'SP', 'correspondencia'),
    (11,'Rua Teste 9', '66896-899', '123', 'Bairro Teste 9', 'Sao Jose do Rio Preto', 'SP', 'entrega'),
    (12,'Rua Teste 10', '66896-899', '123', 'Bairro Teste 10', 'Sao Jose do Rio Preto', 'SP', 'correspondencia');
    