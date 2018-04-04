# Microsoft Visual C++ generated build script - Do not modify

PROJ = DIBAPI
DEBUG = 1
PROGTYPE = 1
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
FIRSTC = COPY.C      
FIRSTCPP =             
RC = rc
CFLAGS_D_WDLL = /nologo /G2 /W3 /Zi /ALw /Od /D "_DEBUG" /FR /Gw /Fd"DIBAPI.PDB"
CFLAGS_R_WDLL = /nologo /W3 /ALw /O1 /D "NDEBUG" /FR /Gw 
LFLAGS_D_WDLL = /NOLOGO /ONERROR:NOEXE /NOD /PACKC:61440 /CO /NOE /ALIGN:16 /MAP:FULL
LFLAGS_R_WDLL = /NOLOGO /ONERROR:NOEXE /NOD /PACKC:61440 /NOE /ALIGN:16 /MAP:FULL
LIBS_D_WDLL = lafxdwd oldnames libw commdlg shell olecli olesvr ldllcew
LIBS_R_WDLL = lafxdw oldnames libw commdlg shell olecli olesvr ldllcew
RCFLAGS = /nologo
RESFLAGS = /nologo
RUNFLAGS = 
DEFFILE = DIBAPI.DEF
OBJS_EXT = LIBENTRY.OBJ 
LIBS_EXT = 
!if "$(DEBUG)" == "1"
CFLAGS = $(CFLAGS_D_WDLL)
LFLAGS = $(LFLAGS_D_WDLL)
LIBS = $(LIBS_D_WDLL)
MAPFILE = nul
RCDEFINES = $(D_RCDEFINES)
!else
CFLAGS = $(CFLAGS_R_WDLL)
LFLAGS = $(LFLAGS_R_WDLL)
LIBS = $(LIBS_R_WDLL)
MAPFILE = nul
RCDEFINES = $(R_RCDEFINES)
!endif
!if [if exist MSVC.BND del MSVC.BND]
!endif
SBRS = COPY.SBR \
		FILE.SBR \
		DIBUTIL.SBR \
		ERRORS.SBR \
		HOOK.SBR \
		PRINT.SBR \
		WEPCODE.SBR \
		DLLINIT.SBR


LIBENTRY_DEP = 

COPY_DEP = d:\wincap\dibutil.h \
	d:\wincap\dibapi.h


FILE_DEP = d:\wincap\dibutil.h \
	d:\wincap\dibapi.h


DIBUTIL_DEP = d:\wincap\dibapi.h \
	d:\wincap\dibutil.h


ERRORS_DEP = d:\wincap\dibapi.h


HOOK_DEP = d:\wincap\wincap.h


PRINT_DEP = d:\wincap\dibdll.h \
	d:\wincap\dibapi.h \
	d:\wincap\dibutil.h


WEPCODE_DEP = 

DLLINIT_DEP = d:\wincap\dibdll.h


DIBAPI_RCDEP = d:\wincap\dibdll.h \
	d:\wincap\printer.ico


all:	$(PROJ).DLL $(PROJ).BSC

COPY.OBJ:	COPY.C $(COPY_DEP)
	$(CC) $(CFLAGS) $(CCREATEPCHFLAG) /c COPY.C

FILE.OBJ:	FILE.C $(FILE_DEP)
	$(CC) $(CFLAGS) $(CUSEPCHFLAG) /c FILE.C

DIBUTIL.OBJ:	DIBUTIL.C $(DIBUTIL_DEP)
	$(CC) $(CFLAGS) $(CUSEPCHFLAG) /c DIBUTIL.C

ERRORS.OBJ:	ERRORS.C $(ERRORS_DEP)
	$(CC) $(CFLAGS) $(CUSEPCHFLAG) /c ERRORS.C

HOOK.OBJ:	HOOK.C $(HOOK_DEP)
	$(CC) $(CFLAGS) $(CUSEPCHFLAG) /c HOOK.C

PRINT.OBJ:	PRINT.C $(PRINT_DEP)
	$(CC) $(CFLAGS) $(CUSEPCHFLAG) /c PRINT.C

WEPCODE.OBJ:	WEPCODE.C $(WEPCODE_DEP)
	$(CC) $(CFLAGS) $(CUSEPCHFLAG) /c WEPCODE.C

DLLINIT.OBJ:	DLLINIT.C $(DLLINIT_DEP)
	$(CC) $(CFLAGS) $(CUSEPCHFLAG) /c DLLINIT.C

DIBAPI.RES:	DIBAPI.RC $(DIBAPI_RCDEP)
	$(RC) $(RCFLAGS) $(RCDEFINES) -r DIBAPI.RC


$(PROJ).DLL::	DIBAPI.RES

$(PROJ).DLL::	COPY.OBJ FILE.OBJ DIBUTIL.OBJ ERRORS.OBJ HOOK.OBJ PRINT.OBJ WEPCODE.OBJ \
	DLLINIT.OBJ $(OBJS_EXT) $(DEFFILE)
	echo >NUL @<<$(PROJ).CRF
COPY.OBJ +
FILE.OBJ +
DIBUTIL.OBJ +
ERRORS.OBJ +
HOOK.OBJ +
PRINT.OBJ +
WEPCODE.OBJ +
DLLINIT.OBJ +
$(OBJS_EXT)
$(PROJ).DLL
$(MAPFILE)
d:\msvc\lib\+
d:\msvc\mfc\lib\+
d:\wing\lib\+
$(LIBS)
$(DEFFILE);
<<
	link $(LFLAGS) @$(PROJ).CRF
	$(RC) $(RESFLAGS) DIBAPI.RES $@
	@copy $(PROJ).CRF MSVC.BND
	implib /nowep $(PROJ).LIB $(PROJ).DLL

$(PROJ).DLL::	DIBAPI.RES
	if not exist MSVC.BND 	$(RC) $(RESFLAGS) DIBAPI.RES $@

run: $(PROJ).DLL
	$(PROJ) $(RUNFLAGS)


$(PROJ).BSC: $(SBRS)
	bscmake @<<
/o$@ $(SBRS)
<<
