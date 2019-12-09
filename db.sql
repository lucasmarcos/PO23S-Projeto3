DROP TABLE IF EXISTS produto_comprado;
DROP TABLE IF EXISTS nota;
DROP TABLE IF EXISTS produto;
DROP TABLE IF EXISTS cliente;
DROP TABLE IF EXISTS configuracao;

CREATE TABLE cliente (
	codigo SERIAL PRIMARY KEY,
	nome VARCHAR,
	cpf VARCHAR,
	endereco VARCHAR,
	bairro VARCHAR,
	cep VARCHAR,
	cidade VARCHAR,
	telefone VARCHAR,
	uf VARCHAR
);

CREATE TABLE produto (
	codigo SERIAL PRIMARY KEY,
	nome VARCHAR,
	valor INT,
	unidade VARCHAR
);

CREATE TABLE nota (
	codigo SERIAL PRIMARY KEY,
	cliente INT NOT NULL REFERENCES cliente(codigo),
	data TIMESTAMP
);

CREATE TABLE produto_comprado (
	nota INT NOT NULL REFERENCES nota(codigo) ON DELETE CASCADE,
	produto INT NOT NULL REFERENCES produto(codigo) ON DELETE CASCADE,
	quantidade INT
);

CREATE TABLE configuracao (
	chave VARCHAR PRIMARY KEY,
	valor VARCHAR
);

-- INSERT INTO cliente (codigo, nome, cpf,	endereco, bairro, cep, cidade, telefone, uf) VALUES
-- 	(100, 'Angela Abar', '12345678910', 'Padaria', 'Centro', '9', 'Tulsa', '12', 'OK');
 
-- INSERT INTO produto (codigo, nome, valor, unidade) VALUES
-- 	(100, 'DualShock 5', 20000, 'cx.'),
-- 	(101, 'Agua', 10, 'ml'),
-- 	(102, 'Redmi K32', 200000, 'un.');

-- INSERT INTO nota (codigo, cliente, data) VALUES
-- 	(100, 100, current_timestamp);

-- INSERT INTO produto_comprado (nota, produto, quantidade) VALUES
-- 	(100, 100, 2),
-- 	(100, 101, 5000),
-- 	(100, 102, 5);

INSERT INTO configuracao (chave, valor) VALUES
	('empresa.nome',     'Valve'),
	('empresa.cnpj',     '10987654321'),
	('empresa.uf',       'PR'),
	('empresa.bairro',   'Centro'),
	('empresa.cidade',   'Dois Vizinhos'),
	('empresa.telefone', '+1 (49) 0000-9999'),
	('empresa.cep',      '85660-000'),
	('empresa.rua',      'Rua Goiás, 92');
