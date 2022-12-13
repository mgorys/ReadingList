export async function get(url, paramsObj) {
  let wholeUrl;

  if (paramsObj) {
    wholeUrl = buildUrl(url, paramsObj);
  } else {
    wholeUrl = url;
  }

  let response = await fetch(wholeUrl, {
    headers: { 'content-type': 'application/json' },
    method: 'GET',
    credentials: 'same-origin',
  });

  if (!response.ok) {
    throw new Error(response.statusText);
  }

  let result = await response.json();
  return result;
}

export async function post(url, data) {
  let response = await fetch(url, {
    body: JSON.stringify(data),
    credentials: 'same-origin',
    headers: {
      'content-type': 'application/json',
    },
    method: 'POST',
  });

  if (!response.ok) {
    throw new Error(response.statusText);
  }

  return await response.json();
}

function convertToURLParams(object) {
  var str = '';
  for (var key in object) {
    if (str != '') {
      str += '&';
    }
    str += key + '=' + encodeURIComponent(object[key]);
  }
  return str;
}

export function buildUrl(url, paramsObj) {
  let wholeUrl = url;

  if (!(url.endsWith('?') || url.endsWith('&')) && paramsObj != null) {
    wholeUrl = wholeUrl + '?';
  }
  if (paramsObj != null) {
    wholeUrl = wholeUrl + convertToURLParams(paramsObj);
  }

  return wholeUrl;
}
