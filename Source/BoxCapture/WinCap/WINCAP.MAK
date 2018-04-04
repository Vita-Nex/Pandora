# Microsoft Visual C++ generated build script - Do not modify

PROJ = WINCAP
DEBUG = 1
PROGTYPE = 0
CALLER = 
ARGS = 
DLLS = 
D_RCDEFINES = -d_DEBUG
R_RCDEFINES = -dNDEBUG
ORIGIN = MSVC
ORIGIN_VER = 1.00
PROJPATH = D:\WINCAP\
USEMFC = 1
CC = cl
CPP = cl
CXX = cl
CCREATEPCHFLAG = 
CPPCREATEPCHFLAG = 
CUSEPCHFLAG = 
CPPUSEPCHFLAG = 
FIRSTC = WINCAP.C    
FIRSTCPP =             
RC = rc
CFLAGS_D_WEXE = /nologo /W3 /FR /G2 /Zi /D_DEBUG /Od /AM /GA /Fd"WINCAP.PDB"
CFLAGS_R_WEXE = /nologo /W3 /FR /O1 /DNDEBUG /AM /GA
LFLAGS_D_WEXE = /NOLOGO /NOD /PACKC:61440 /ALIGN:16 /ONERROR:NOEXE /CO  
LFLAGS_R_WEXE = /NOLOGO /NOD /PACKC:61440 /ALIGN:16 /ONERROR:NOEXE  
LIBS_D_WEXE = mafxcwd oldnames libw mlibcew commdlg.lib olecli.lib olesvr.lib shell.lib 
LIBS_R_WEXE = mafxcw oldnames libw mlibcew commdlg.lib olecli.lib olesvr.lib shell.lib 
RCFLAGS = /nologo
RESFLAGS = /nologo
RUNFLAGS = 
DEFFILE = WINCAP.DEF
OBJS_EXT = 
LIBS_EXT = DIBAPI.LIB 
!if "$(DEBUG)" == "1"
CFLAGS = $(CFLAGS_D_WEXE)
LFLAGS = $(LFLAGS_D_WEXE)
LIBS = $(LIBS_D_WEXE)
MAPFILE = nul
RCDEFINES = $(D_RCDEFINES)
!else
CFLAGS = $(CFLAGS_R_WEXE)
LFLAGS = $(LFLAGS_R_WEXE)
LIBS = $(LIBS_R_WEXE)
MAPFILE = nul
RCDEFINES = $(R_RCDEFINES)
!endif
!if [if exist MSVC.BND del MSVC.BND]
!endif
SBRS = WINCAP.SBR \
		DLGOPEN.SBR \
		DIALOGS.SBR


DIBAPI_DEP = 

WINCAP_RCDEP = d:\wincap\wincap.h \
	d:\wincap\dialogs.h \
	d:\wincap\wincap.ico \
	d:\wincap\startup.bmp \
	d:\wincap\select.cur \
	d:\wincap\about.bmp \
	d:\wincap\dialogs.dlg


WINCAP_DEP = d:\wincap\wincap.h \
	d:\wincap\dialogs.h \
	d:\wincap\dibapi.h


DLGOPEN_DEP = d:\wincap\wincap.h \
	d:\wincap\dialogs.h


DIALOGS_DEP = d:\wincap\wincap.h \
	d:\wincap\dialogs.h


all:	$(PROJ).EXE $(PROJ).BSC

WINCAP.RES:	WINCAP.RC $(WINCAP_RCDEP)
	$(RC) $(RCFLAGS) $(RCDEFINES) -r WINCAP.RC

WINCAP.OBJ:	WINCAP.C $(WINCAP_DEP)
	$(CC) $(CFLAGS) $(CCREATEPCHFLAG) /c WINCAP.C

DLGOPEN.OBJ:	DLGOPEN.C $(DLGOPEN_DEP)
	$(CC) $(CFLAGS) $(CUSEPCHFLAG) /c DLGOPEN.C

DIALOGS.OBJ:	DIALOGS.C $(DIALOGS_DEP)
	$(CC) $(CFLAGS) $(CUSEPCHFLAG) /c DIALOGS.C


$(PROJ).EXE::	WINCAP.RES

$(PROJ).EXE::	WINCAP.OBJ DLGOPEN.OBJ DIALOGS.OBJ $(OBJS_EXT) $(DEFFILE)
	echo >NUL @<<$(PROJ).CRF
WINCAP.OBJ +
DLGOPEN.OBJ +
DIALOGS.OBJ +
$(OBJS_EXT)
$(PROJ).EXE
$(MAPFILE)
d:\msvc\lib\+
d:\msvc\mfc\lib\+
d:\wing\lib\+
DIBAPI.LIB+
$(LIBS)
$(DEFFILE);
<<
	link $(LFLAGS) @$(PROJ).CRF
	$(RC) $(RESFLAGS) WINCAP.RES $@
	@copy $(PROJ).CRF MSVC.BND

$(PROJ).EXE::	WINCAP.RES
	if not exist MSVC.BND 	$(RC) $(RESFLAGS) WINCAP.RES $@

run: $(PROJ).EXE
	$(PROJ) $(RUNFLAGS)


$(PROJ).BSC: $(SBRS)
	bscmake @<<
/o$@ $(SBRS)
<<
