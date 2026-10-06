program test;

var
    res : integer;
    point : record
        x : integer;
        y : integer;
    end;

begin
    with point do
    begin
        x := 10;
        y := 45;
    end;

    res := point.x + point.y;
end.
