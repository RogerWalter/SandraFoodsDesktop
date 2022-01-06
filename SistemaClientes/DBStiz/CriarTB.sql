CREATE TABLE ENTREGA (
    ID INTEGER,
    ID_PEDIDO INTEGER,
    SENHA INTEGER,
    CLIENTE CHAR(40),
    TOTAL NUMERIC(15,2),
    TAXA NUMERIC(15,2),
    ENTREGADOR INTEGER,
    DATA CHAR(10),
    PAGAMENTO INTEGER);

INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (1, 1, NULL, 'ROGER                                   ', 15, 3, NULL, NULL, NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (2, 79, 1, 'MARGARETE                               ', 38, 7, 1, NULL, NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (3, 80, 2, 'ANDREIA                                 ', 28, 7, 2, NULL, NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (4, 82, 4, 'MIODUTZKI                               ', 53, 3, 3, NULL, NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (6, 83, 1, 'FERNANDA                                ', 33.5, 3, 1, '11/06/2020', NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (7, 84, 2, 'ANGELA                                  ', 61, 7, 1, '11/06/2020', NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (8, 85, 3, 'ROSANA                                  ', 88, 3, 2, '11/06/2020', NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (5, 82, 5, 'ROGER                                   ', 99, 5, 0, NULL, NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (12, 101, 12, 'ANDREIA                                 ', 22, 7, 1, '12/06/2020', NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (13, 0, 1, 'PEDIDOS 10                              ', 25, 5, 2, '12/06/2020', NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (14, 0, 2, 'PEDIDOS 10                              ', 50, 10, 2, '12/06/2020', NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (9, 0, 1, 'PEDIDOS 10                              ', 50, 5, 1, '11/06/2020', NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (10, 0, 2, 'PEDIDOS 10                              ', 30, 3, 2, '11/06/2020', NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (15, 106, 1, 'VANDERLEIA                              ', 14, 3, 2, '13/06/2020', NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (16, 0, 1, 'PEDIDOS 10                              ', 34, 5, 2, '13/06/2020', NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (11, 0, 3, 'PEDIDOS 10                              ', 111, 11, 2, '11/06/2020', NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (17, 107, 2, 'MARGARETE                               ', 22, 7, 0, '13/06/2020', NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (18, 110, 3, 'MILENA                                  ', 20, 3, 1, '15/06/2020', NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (19, 112, 5, 'IVONETE                                 ', 38, 3, 1, '15/06/2020', NULL);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (20, 0, 1, 'PEDIDOS 10                              ', 50, 10, 2, '15/06/2020', 1);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (21, 113, 6, 'MARCIA                                  ', 6, 3, 2, '15/06/2020', 1);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (22, 0, 2, 'PEDIDOS 10                              ', 99, 10, 1, '15/06/2020', 2);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (23, 115, 8, 'MARGARETE                               ', 24, 7, 2, '15/06/2020', 1);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (24, 0, 3, 'PEDIDOS 10                              ', 55, 30, 1, '15/06/2020', 1);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (25, 0, 4, 'PEDIDOS 10                              ', 45, 5, 2, '15/06/2020', 2);
INSERT INTO ENTREGA (ID, ID_PEDIDO, SENHA, CLIENTE, TOTAL, TAXA, ENTREGADOR, DATA, PAGAMENTO)
             VALUES (26, 0, 5, 'PEDIDOS 10                              ', 56, 7, 2, '15/06/2020', 2);

COMMIT WORK;