CREATE TABLE new_hasil_lifting (
  id_hasil                 FLOAT(126)    NOT NULL,
  id_ctp                   VARCHAR2(50)  NOT NULL,
  lifting_date             DATE          NOT NULL,
  kode_bl                  VARCHAR2(50)  NULL,
  id_entitas               NVARCHAR2(50) NOT NULL,
  id_parent                NVARCHAR2(50) NULL,
  type_entitas             NVARCHAR2(50) NULL,
  entitas_level            INTEGER       NULL,
  entitas_origin_out       FLOAT(126)    NULL,
  entitas_parent_summary   FLOAT(126)    NULL,
  entitas_production_alloc FLOAT(126)    NULL,
  entitas_lifting_alloc    FLOAT(126)    NULL,
  entitas_real_prod_alloc  FLOAT(126)    NULL,
  entitas_real_lift_alloc  FLOAT(126)    NULL,
  jenis_produk             FLOAT(126)    NOT NULL,
  aliran_produk            FLOAT(126)    NULL,
  final_lifting_value      FLOAT(126)    DEFAULT (0.00) NULL,
  entitas_end              INTEGER       NULL,
  fin_lifting_scada        FLOAT(126)    DEFAULT 0 NULL
)
  STORAGE (
    INITIAL    7168 K
    NEXT       1024 K
  )
/

CREATE INDEX ix_new_hasil_lifting_dec2011
  ON new_hasil_lifting (
    id_ctp,
    lifting_date,
    jenis_produk,
    id_entitas,
    id_parent,
    type_entitas
  )
  STORAGE (
    INITIAL    5120 K
    NEXT       1024 K
  )
/

ALTER TABLE new_hasil_lifting
  ADD PRIMARY KEY (
    id_hasil
  )
  USING INDEX
    STORAGE (
      INITIAL     768 K
      NEXT       1024 K
    )
/

CREATE OR REPLACE TRIGGER tri_new_hasil_lifting_b
BEFORE INSERT
ON new_hasil_lifting
REFERENCING NEW AS NEW OLD AS OLD
FOR EACH ROW
DECLARE
tmpVar NUMBER;
/******************************************************************************
   NAME:
   PURPOSE:

   REVISIONS:
   Ver        Date        Author           Description
   ---------  ----------  ---------------  ------------------------------------
   1.0        2011-12-23             1. Created this trigger.

   NOTES:

   Automatically available Auto Replace Keywords:
      Object Name:
      Sysdate:         2011-12-23
      Date and Time:   2011-12-23, 11:22:45 AM, and 2011-12-23 11:22:45 AM
      Username:         (set in TOAD Options, Proc Templates)
      Table Name:      NEW_HASIL_LIFTING (set in the "New PL/SQL Object" dialog)
      Trigger Options:  (set in the "New PL/SQL Object" dialog)
******************************************************************************/
BEGIN
   tmpVar := 0;

      IF (:NEW.ID_HASIL IS NULL OR :NEW.ID_HASIL = 0) THEN
   SELECT SEQ_ID_HASIL.NEXTVAL INTO tmpVar FROM dual;
   :NEW.ID_HASIL := tmpVar;
   END IF;

END ;
/

COMMENT ON COLUMN new_hasil_lifting.entitas_origin_out IS 'ENTITAS_OUT';
COMMENT ON COLUMN new_hasil_lifting.entitas_parent_summary IS 'ENTITAS_RECEIVE';
COMMENT ON COLUMN new_hasil_lifting.entitas_lifting_alloc IS 'ENTITAS_ALLOC';

======================================================================================================================

CREATE TABLE lq_well_test (
  id            FLOAT(126)     NOT NULL,
  id_kps        NVARCHAR2(50)  NOT NULL,
  id_sumur      NVARCHAR2(50)  NOT NULL,
  tgl_test      DATE           NOT NULL,
  p_oil         FLOAT(126)     NULL,
  p_gas         FLOAT(126)     NULL,
  p_water       FLOAT(126)     NULL,
  durasi        FLOAT(126)     DEFAULT (0) NULL,
  t_oil         FLOAT(126)     NULL,
  t_gas         FLOAT(126)     NULL,
  t_water       FLOAT(126)     NULL,
  hours_prod    FLOAT(126)     NULL,
  e_oil         FLOAT(126)     NULL,
  e_gas         FLOAT(126)     NULL,
  e_water       FLOAT(126)     NULL,
  id_sp         NVARCHAR2(50)  NULL,
  valid         INTEGER        DEFAULT (0) NULL,
  satuan_oil    NVARCHAR2(100) NULL,
  satuan_gas    NVARCHAR2(100) NULL,
  satuan_water  NVARCHAR2(100) NULL,
  status_proses INTEGER        DEFAULT (0) NULL,
  i_user        NVARCHAR2(50)  NULL,
  i_date        DATE           NULL,
  u_user        NVARCHAR2(50)  NULL,
  u_date        DATE           NULL,
  history_id    FLOAT(126)     NULL,
  id1           FLOAT(126)     NULL,
  id2           FLOAT(126)     NULL
)
  STORAGE (
    INITIAL  118784 K
    NEXT       1024 K
  )
/

CREATE INDEX ix_lq_well_test
  ON lq_well_test (
    id_sumur,
    tgl_test
  )
  STORAGE (
    INITIAL   56320 K
    NEXT       1024 K
  )
/

ALTER TABLE lq_well_test
  ADD PRIMARY KEY (
    id,
    id_kps,
    id_sumur,
    tgl_test
  )
  USING INDEX
    STORAGE (
      INITIAL   90112 K
      NEXT       1024 K
    )
/

=======================================================================================================================================

CREATE TABLE lq_well_prod_duration (
  id_sumur   NVARCHAR2(50) NOT NULL,
  tgl_test   DATE          NOT NULL,
  id         FLOAT(126)    NOT NULL,
  durasi     FLOAT(126)    NULL,
  id_kps     NVARCHAR2(50) NULL,
  id_sp      NVARCHAR2(50) NULL,
  p_oil      FLOAT(126)    NULL,
  p_gas      FLOAT(126)    NULL,
  i_user     NVARCHAR2(50) NULL,
  i_date     DATE          NULL,
  u_user     NVARCHAR2(50) NULL,
  u_date     DATE          NULL,
  history_id FLOAT(126)    NULL,
  id1        FLOAT(126)    NULL,
  id2        FLOAT(126)    NULL
)
  STORAGE (
    INITIAL  490496 K
    NEXT       1024 K
  )
/

ALTER TABLE lq_well_prod_duration
  ADD CONSTRAINT wellduration_unique UNIQUE (
    id_sumur,
    tgl_test
  )
  USING INDEX
    STORAGE (
      NEXT       1024 K
    )
/

=========================================================================================================================================

CREATE TABLE lq_well_network_history (
  id_sumur    VARCHAR2(50)  NOT NULL,
  id_sp       VARCHAR2(100) NOT NULL,
  tgl_network DATE          NOT NULL,
  id          FLOAT(126)    NOT NULL,
  i_user      VARCHAR2(50)  NULL,
  i_date      DATE          NULL,
  u_user      VARCHAR2(50)  NULL,
  u_date      DATE          NULL,
  history_id  FLOAT(126)    NULL,
  id1         FLOAT(126)    NULL,
  id2         FLOAT(126)    NULL,
  id_kps      VARCHAR2(400) NULL
)
  STORAGE (
    INITIAL    7168 K
    NEXT       1024 K
  )
/

ALTER TABLE lq_well_network_history
  ADD PRIMARY KEY (
    id_sumur,
    id_sp,
    tgl_network
  )
  USING INDEX
    STORAGE (
      INITIAL    6144 K
      NEXT       1024 K
    )
/

=================================================================================================================================================

CREATE TABLE lq_well_dpm (
  id               FLOAT(126)    NOT NULL,
  well_name        VARCHAR2(200) NULL,
  daerah_penghasil VARCHAR2(200) NULL,
  tgl_efektif      DATE          NULL,
  i_user           NVARCHAR2(50) NULL,
  i_date           DATE          NULL,
  u_user           NVARCHAR2(50) NULL,
  u_date           DATE          NULL,
  id_kps           VARCHAR2(50)  NULL
)
  STORAGE (
    NEXT       1024 K
  )
/

ALTER TABLE lq_well_dpm
  ADD CONSTRAINT well_unique UNIQUE (
    well_name,
    daerah_penghasil
  )
  USING INDEX
    STORAGE (
      NEXT       1024 K
    )
/

===============================================================================================================================================

CREATE TABLE lq_tr_ctp (
  id                 FLOAT(126)    NOT NULL,
  id_ctp             NVARCHAR2(50) NOT NULL,
  kalibrasi_terakhir DATE          NOT NULL,
  jenis_minyak       INTEGER       NOT NULL,
  id_kps             NVARCHAR2(50) NULL,
  vol_lifting        FLOAT(126)    NULL,
  valid              INTEGER       NULL,
  p_minyak           FLOAT(126)    NULL,
  p_gas              FLOAT(126)    NULL,
  status_proses      INTEGER       DEFAULT (0) NULL,
  i_user             NVARCHAR2(50) NULL,
  i_date             DATE          NULL,
  u_user             NVARCHAR2(50) NULL,
  u_date             DATE          NULL,
  history_id         FLOAT(126)    NULL,
  id1                FLOAT(126)    NULL,
  id2                FLOAT(126)    NULL,
  mmbtu              FLOAT(126)    NULL,
  kode_bl            VARCHAR2(50)  DEFAULT '-' NOT NULL
)
  STORAGE (
    NEXT       1024 K
  )
/

ALTER TABLE lq_tr_ctp
  ADD PRIMARY KEY (
    id,
    id_ctp,
    kalibrasi_terakhir,
    jenis_minyak
  )
  USING INDEX
    STORAGE (
      INITIAL     896 K
      NEXT       1024 K
    )
/

CREATE OR REPLACE TRIGGER tri_lq_tr_ctp_in
BEFORE INSERT
ON lq_tr_ctp
REFERENCING NEW AS NEW OLD AS OLD
FOR EACH ROW
DECLARE
tmpVar NUMBER;
BEGIN
   tmpVar := 0;
   SELECT SEQ_ID_CTP.NEXTVAL INTO tmpVar FROM dual;
   :NEW.ID := tmpVar;
END LQ_TR_CTP_IN;
/

CREATE OR REPLACE TRIGGER tri_lq_tr_ctp_up
BEFORE UPDATE
OF STATUS_PROSES
ON lq_tr_ctp
REFERENCING NEW AS NEW OLD AS OLD
FOR EACH ROW
DECLARE
   TOTAL_OUT       FLOAT;
   ANID_CTP        VARCHAR2 (50);
   ALIFTING_DATE   LQ_TR_CTP.KALIBRASI_TERAKHIR%TYPE;
   AJENIS_PRODUK   LQ_TR_CTP.JENIS_MINYAK%TYPE;
   AKODE_BL        LQ_TR_CTP.KODE_BL%TYPE;
   AVOL_LIFTING    LQ_TR_CTP.VOL_LIFTING%TYPE;
BEGIN
   ANID_CTP := :NEW.ID_CTP;
   ALIFTING_DATE := :NEW.KALIBRASI_TERAKHIR;
   AJENIS_PRODUK := :NEW.JENIS_MINYAK;
   AKODE_BL := :NEW.KODE_BL;
   AVOL_LIFTING := :NEW.VOL_LIFTING;
   IF (:NEW.STATUS_PROSES = 0)
   THEN
   	   IF (AKODE_BL IS NOT NULL) THEN
      DELETE FROM NEW_HASIL_LIFTING
            WHERE (ID_CTP = ANID_CTP)
              AND (LIFTING_DATE = ALIFTING_DATE)
              AND (JENIS_PRODUK = AJENIS_PRODUK)
              AND (KODE_BL = AKODE_BL);
	ELSE
	DELETE FROM NEW_HASIL_LIFTING
            WHERE (ID_CTP = ANID_CTP)
              AND (LIFTING_DATE = ALIFTING_DATE)
              AND (JENIS_PRODUK = AJENIS_PRODUK)
              AND (KODE_BL IS NULL);
	END IF;
   ELSIF (:NEW.STATUS_PROSES = 1)
   THEN
      IF (AKODE_BL IS NULL)
      THEN
	  	 BEGIN
         SELECT   SUM (NEW_HASIL_LIFTING.ENTITAS_ORIGIN_OUT)
             INTO TOTAL_OUT
             FROM NEW_HASIL_LIFTING
            WHERE (NEW_HASIL_LIFTING.TYPE_ENTITAS = 2)
              AND (NEW_HASIL_LIFTING.ID_CTP = ANID_CTP)
              AND (NEW_HASIL_LIFTING.LIFTING_DATE = ALIFTING_DATE)
              AND (NEW_HASIL_LIFTING.JENIS_PRODUK = AJENIS_PRODUK)
              AND (NEW_HASIL_LIFTING.KODE_BL IS NULL)
         GROUP BY NEW_HASIL_LIFTING.ID_CTP,
                  NEW_HASIL_LIFTING.LIFTING_DATE,
                  NEW_HASIL_LIFTING.JENIS_PRODUK,
                  NEW_HASIL_LIFTING.KODE_BL;
				 EXCEPTION WHEN NO_DATA_FOUND THEN RETURN;
		END;
      ELSE
	  	  BEGIN
         SELECT   SUM (NEW_HASIL_LIFTING.ENTITAS_ORIGIN_OUT)
             INTO TOTAL_OUT
             FROM NEW_HASIL_LIFTING
            WHERE (NEW_HASIL_LIFTING.TYPE_ENTITAS = 2)
              AND (NEW_HASIL_LIFTING.ID_CTP = ANID_CTP)
              AND (NEW_HASIL_LIFTING.LIFTING_DATE = ALIFTING_DATE)
              AND (NEW_HASIL_LIFTING.JENIS_PRODUK = AJENIS_PRODUK)
              AND (NEW_HASIL_LIFTING.KODE_BL = AKODE_BL)
         GROUP BY NEW_HASIL_LIFTING.ID_CTP,
                  NEW_HASIL_LIFTING.LIFTING_DATE,
                  NEW_HASIL_LIFTING.JENIS_PRODUK,
                  NEW_HASIL_LIFTING.KODE_BL;
				  EXCEPTION WHEN NO_DATA_FOUND THEN RETURN;
		END;
      END IF;
      UPDATE NEW_HASIL_LIFTING
         SET NEW_HASIL_LIFTING.FINAL_LIFTING_VALUE =
                NEW_HASIL_LIFTING.ENTITAS_ORIGIN_OUT / TOTAL_OUT
                * AVOL_LIFTING;
   END IF;
EXCEPTION
   WHEN OTHERS
   THEN
      -- CONSIDER LOGGING THE ERROR AND THEN RE-RAISE
      RAISE;
END TRI_LQ_TR_CTP_UP;
/

===========================================================================================================================================

CREATE TABLE lq_r_well_group (
  well_group_name VARCHAR2(50) NOT NULL,
  id_kps          VARCHAR2(50) NOT NULL,
  id              FLOAT(126)   NOT NULL,
  area_id         VARCHAR2(50) NULL,
  blok            VARCHAR2(50) NULL,
  i_user          VARCHAR2(50) NULL,
  i_date          DATE         NULL,
  u_user          VARCHAR2(50) NULL,
  u_date          DATE         NULL,
  history_id      FLOAT(126)   NULL,
  id1             FLOAT(126)   NULL,
  id2             FLOAT(126)   NULL
)
  STORAGE (
    INITIAL     128 K
    NEXT       1024 K
  )
/

CREATE INDEX ix_lq_r_well_group
  ON lq_r_well_group (
    id
  )
  STORAGE (
    NEXT       1024 K
  )
/

ALTER TABLE lq_r_well_group
  ADD PRIMARY KEY (
    well_group_name,
    id_kps
  )
  USING INDEX
    STORAGE (
      NEXT       1024 K
    )
/

ALTER TABLE lq_r_well_group
  ADD CONSTRAINT well_group_unique UNIQUE (
    well_group_name
  )
  USING INDEX
    STORAGE (
      NEXT       1024 K
    )
/

================================================================================================================================================

CREATE TABLE lq_r_sumur (
  well_name        VARCHAR2(200)  NOT NULL,
  nama_sumur       VARCHAR2(200)  NOT NULL,
  id_kps           VARCHAR2(50)   NOT NULL,
  id               FLOAT(126)     NOT NULL,
  id_sumur         VARCHAR2(50)   NOT NULL,
  k_longitude      VARCHAR2(50)   NULL,
  k_latitude       VARCHAR2(50)   NULL,
  jenis_sumur      VARCHAR2(100)  NULL,
  keterangan       VARCHAR2(1024) NULL,
  valid            INTEGER        DEFAULT (0) NULL,
  proses_status    INTEGER        NULL,
  jenis_minyak     INTEGER        NULL,
  text_minyake     VARCHAR2(100)  NULL,
  id_well_group    VARCHAR2(50)   NULL,
  confidence_level FLOAT(126)     DEFAULT (1) NULL,
  i_user           NVARCHAR2(50)  NULL,
  i_date           DATE           NULL,
  u_user           NVARCHAR2(50)  NULL,
  u_date           DATE           NULL,
  history_id       FLOAT(126)     NULL,
  id1              FLOAT(126)     NULL,
  id2              FLOAT(126)     NULL
)
  STORAGE (
    NEXT       1024 K
  )
/

ALTER TABLE lq_r_sumur
  ADD PRIMARY KEY (
    id_sumur,
    id_kps
  )
  USING INDEX
    STORAGE (
      INITIAL    2048 K
      NEXT       1024 K
    )
/

ALTER TABLE lq_r_sumur
  ADD CONSTRAINT wellinfo_unique UNIQUE (
    id_sumur
  )
  USING INDEX
    STORAGE (
      NEXT       1024 K
    )
/

============================================================================================================================================

CREATE TABLE lq_product_type (
  product_type INTEGER      NOT NULL,
  description  VARCHAR2(50) NULL,
  i_user       VARCHAR2(50) NULL,
  i_date       DATE         NULL,
  u_use        VARCHAR2(50) NULL,
  u_date       DATE         NULL
)
  STORAGE (
    NEXT       1024 K
  )
/

ALTER TABLE lq_product_type
  ADD CONSTRAINT pk_lq_product_type PRIMARY KEY (
    product_type
  )
  USING INDEX
    STORAGE (
      NEXT       1024 K
/
    )

==============================================================================================================================================

CREATE TABLE "BACKALLOCPROJ"."userlogin" (
"user_id" NUMBER NOT NULL primary key,
"username" VARCHAR2(32 BYTE) NULL ,
"password" VARCHAR2(32 BYTE) NULL ,
"group" NUMBER NULL ,
"created" DATE NULL ,
"modified" DATE NULL ,
"last_login" DATE NULL ,
"ip" VARCHAR2(32 BYTE) NULL ,
"browser" VARCHAR2(32 BYTE) NULL 
)
LOGGING
NOCOMPRESS
NOCACHE
;